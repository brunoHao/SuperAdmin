using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperAdmin.Models;
using SuperAdmin.Models.Shop;

namespace SuperAdmin.Controllers
{
    public class SupplierController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly MyDatabase _myDatabase;
        public SupplierController(
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
        public ActionResult Index()
        {
            return View(_myDatabase.Suppliers.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Suppliers supp)
        {
            if (ModelState.IsValid)
            {
                _myDatabase.Suppliers.Add(supp);
                _myDatabase.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            Suppliers supp = _myDatabase.Suppliers.Single(x => x.SupplierID == id);
            if (supp == null)
            {
                return null;
            }
            return View(supp);
        }

        [HttpPost]
        public ActionResult Edit(Suppliers supp)
        {
            if (ModelState.IsValid)
            {
                _myDatabase.Entry(supp).State = EntityState.Modified;
                _myDatabase.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supp);
        }

        public ActionResult Details(int id)
        {
            Suppliers supp = _myDatabase.Suppliers.Find(id);
            if (supp == null)
            {
                return null;
            }
            return View(supp);
        }

        public ActionResult Delete(int id)
        {
            Suppliers supp = _myDatabase.Suppliers.Find(id);
            if (supp == null)
            {
                return null;
            }
            return View(supp);
        }

        //Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suppliers supp = _myDatabase.Suppliers.Find(id);
            _myDatabase.Suppliers.Remove(supp);
            _myDatabase.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

