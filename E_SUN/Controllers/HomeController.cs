using System.Diagnostics;
using E_SUN.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_SUN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string userid, string password)
        {
            E_SUN_BUYContext context = new E_SUN_BUYContext();
            var user = context.Users.FirstOrDefault(u => u.UserId == userid);
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.UserId);
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Message = "身分證錯誤";
                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
