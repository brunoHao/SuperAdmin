using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperAdmin.Models;
using SuperAdmin.Models.Shop;

namespace SuperAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly MyDatabase _myDatabase;
        public ProductController(
          UserManager<AppUser> userManager,
          SignInManager<AppUser> signInManager,
          ILogger<AccountController> logger,
          MyDatabase myDatabase)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _myDatabase = myDatabase;
        }w
        public IActionResult Index()
        {
            var liPro = _myDatabase.Products.ToList();
            return View(liPro);
        }

        public ActionResult Create()
        {
            GetViewBagData();
            return View();
        }
        public void GetViewBagData()
        {
            ViewBag.SupplierID = new SelectList(_myDatabase.Suppliers, "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(_myDatabase.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryID = new SelectList(_myDatabase.SubCategories, "SubCategoryID", "Name");

        }
        [HttpPost]
        public ActionResult Create(Product prod)
        {
            if (ModelState.IsValid)
            {
                //foreach (var file in Picture1)
                //{
                //    if (file != null || file.ContentLength > 0)
                //    {
                //        string ext = System.IO.Path.GetExtension(file.FileName);
                //        if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                //        {
                //            file.SaveAs(Path.Combine(Server.MapPath("/Content/Images/large"), Guid.NewGuid() + Path.GetExtension(file.FileName)));

                //            var medImg= Images.ResizeImage(Image.FromFile(file.FileName), 250, 300);
                //            medImg.Save(Path.Combine(Server.MapPath("/Content/Images/medium"), Guid.NewGuid() + Path.GetExtension(file.FileName)));


                //            var smImg = Images.ResizeImage(Image.FromFile(file.FileName), 45, 55);
                //            smImg.Save(Path.Combine(Server.MapPath("/Content/Images/small"), Guid.NewGuid() + Path.GetExtension(file.FileName)));

                //        }
                //    }
                //    db.Products.Add(prod);
                //    db.SaveChanges();
                //    return RedirectToAction("Index", "Product");
                //}
                _myDatabase.Products.Add(prod);
                _myDatabase.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            GetViewBagData();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = _myDatabase.Products.Single(x => x.ProductID == id);
            if (product == null)
            {
                return null;
            }
            GetViewBagData();
            return View("Edit", product);
        }
        public ActionResult Details(int id)
        {
            Product product = _myDatabase.Products.Find(id);
            if (product == null)
            {
                return null;
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Product product = _myDatabase.Products.Find(id);
            _myDatabase.Products.Remove(product);
            _myDatabase.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
