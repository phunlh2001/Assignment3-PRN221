using Assignment3.Hubs;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<SignalrServer> _signalrHub;
        public PostsController(ApplicationDbContext context, IHubContext<SignalrServer> signalrHub)
        {
            _context = context;
            _signalrHub = signalrHub;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Posts.Include(p => p.Author).Include(p => p.PostCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var res = _context.Posts.ToList();
            return Ok(res);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.PostCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.AppUsers, "ID", "FullName");
            ViewData["CategoryID"] = new SelectList(_context.PostCategories, "ID", "CategoryName");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AuthorID,CategoryID,CreatedDate,UpdatedDate,Title,Content,PublishStatus")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                await _signalrHub.Clients.All.SendAsync("LoadPosts");
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.AppUsers, "ID", "ID", post.AuthorID);
            ViewData["CategoryID"] = new SelectList(_context.PostCategories, "ID", "Description", post.CategoryID);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.AppUsers, "ID", "FullName", post.AuthorID);
            ViewData["CategoryID"] = new SelectList(_context.PostCategories, "ID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AuthorID,CategoryID,CreatedDate,UpdatedDate,Title,Content,PublishStatus")] Post post)
        {
            if (id != post.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                    await _signalrHub.Clients.All.SendAsync("LoadPosts");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.AppUsers, "ID", "ID", post.AuthorID);
            ViewData["CategoryID"] = new SelectList(_context.PostCategories, "ID", "Description", post.CategoryID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.PostCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            await _signalrHub.Clients.All.SendAsync("LoadPosts");
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.ID == id);
        }
    }
}
