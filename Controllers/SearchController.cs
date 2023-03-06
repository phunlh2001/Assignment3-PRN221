using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Assignment3.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetData(string txt)
        {
            var post = _context.Posts.Where(p => p.Title.Contains(txt));

            if (post.Count() > 0)
            {
                return Ok(post);
            }
            return NotFound();
        }
    }
}
