using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperAdmin.Models;
using System.Diagnostics;

namespace SuperAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly MyDatabase _myDatabase;
        public HomeController(
          UserManager<AppUser> userManager,
          SignInManager<AppUser> signInManager,
          MyDatabase myDatabase)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _myDatabase = myDatabase;
        }

        public IActionResult Index()
        {
            return View();
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