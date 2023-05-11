using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperAdmin.Models;

namespace SuperAdmin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly MyDatabase _myDatabase;
        public CustomerController(
          UserManager<AppUser> userManager,
          SignInManager<AppUser> signInManager,
          ILogger<AccountController> logger,
          MyDatabase myDatabase)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _myDatabase = myDatabase;
        }
        public IActionResult Index()
        {
            return View(_myDatabase.Users.ToList());
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var cust = _myDatabase.Users.Where(u => u.Id == id).FirstOrDefault();
            if (cust == null)
            {
                return null;
            }
            return View("Edit", cust);
        }

        public ActionResult Details(string id)
        {
            var cust = _myDatabase.Users.Find(id);
            if (cust == null)
            {
                return null;
            }
            return View(cust);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var cust = _myDatabase.Users.Find(id);
            _myDatabase.Users.Remove(cust);
            _myDatabase.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
