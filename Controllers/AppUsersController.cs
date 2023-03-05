using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class AppUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var res = _context.AppUsers.ToList();
            return View(res);
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string pwd)
        {
            var userExist = _context.AppUsers.FirstOrDefault(e => e.Email == email);
            if (userExist != null && userExist.Password == pwd)
            {
                HttpContext.Session.SetString("user", userExist.FullName);
                HttpContext.Session.SetString("userEmail", userExist.Email);
                HttpContext.Session.SetString("userID", Convert.ToString(userExist.ID));
                return Redirect("/");
            }
            TempData["Error"] = "Login Failed";
            return View();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(string cPwd, AppUser user)
        {
            if (ModelState.IsValid)
            {
                var emailExist = _context.AppUsers.FirstOrDefault(e => e.Email == user.Email);
                if (emailExist != null)
                {
                    ViewBag.error = "Email does exits";
                }
                else if (user.Password == cPwd)
                {
                    _context.AppUsers.Add(user);
                    await _context.SaveChangesAsync();
                    return Redirect("/");
                }
                else
                {
                    ViewBag.error = "Confirm Password invalid";
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("userID");
            HttpContext.Session.Remove("userEmail");
            return Redirect("/");
        }
    }
}
