using Assignment3.Extentions;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var post = _context.SearchByText(txt);

            var category = _context.PostCategories
                .FirstOrDefault(e => e.Description.Contains(txt));
            var post2 = _context.Posts
                .Include(p => p.Author)
                .FirstOrDefault(p => p.PostCategory == category);

            if (post != null)
            {
                return new JsonResult(post);
            }
            else if (category != null)
            {
                return new JsonResult(post2);
            }
            return NoContent();
        }
    }
}
