using Assignment3.Hubs;
using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class AppUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<SignalrServer> _signalrHub;

        public AppUsersController(ApplicationDbContext context, IHubContext<SignalrServer> signalrHub)
        {
            _context = context;
            _signalrHub = signalrHub;
        }

        public IActionResult Index()
        {
            var isLogin = HttpContext.Session.GetString("user") != null; // logined
            var isAdmin = HttpContext.Session.GetString("userEmail") == "admin@gmail.com";
            if (!isLogin && !isAdmin)
            {
                return Redirect("/");
            }
            var res = _context.AppUsers.ToList();
            return View(res);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var res = _context.AppUsers.ToList();
            return Ok(res);
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
                    await _signalrHub.Clients.All.SendAsync("LoadUsers");
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
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
