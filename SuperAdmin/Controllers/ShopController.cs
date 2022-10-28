using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using SuperAdmin.Models;
using SuperAdmin.Models.Shop;

namespace SuperAdmin.Controllers
{
    public class ShopController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly MyDatabase _myDatabase;

        public ShopController(
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
            var product = _myDatabase.Products.ToList();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                IFormCollection _form = Request.Form;

                if (_form.Files.Count > 0)
                {
                    if (!Directory.Exists("wwwroot/img/product/")) Directory.CreateDirectory("wwwroot/img/product/");
                    foreach (var formFile in _form.Files)
                    {
                        if (formFile.Length > 0)
                        {
                            var filePath = "wwwroot/img/product/" + formFile.FileName;
                            using (var stream = new FileStream(filePath, FileMode.Create)) // Mở stream để lưu file, lưu file ở thư mục wwwroot/upload/
                            {
                                formFile.CopyTo(stream);
                            }

                            var imgPath = "/img/product/" + formFile.FileName;
                            var product = new Product()
                            {
                                CategoryId = model.CategoryId,
                                Name = model.Name,
                                Price = model.Price,
                                Desc = model.Desc,
                                Count = model.Count,
                                Image = imgPath,
                            };
                            _myDatabase.Products.Add(product);
                            _myDatabase.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Product model/*, string returnUrl = null*/)
        {
            //returnUrl ??= Url.Content("~/");
            //ViewData["ReturnUrl"] = returnUrl;
            if (id == null)
            {
                return NotFound();
            }
           
            else if (!ModelState.IsValid)
            {
                IFormCollection _form = Request.Form;

                if (_form.Files.Count > 0)
                {
                    if (!Directory.Exists("wwwroot/img/product/")) Directory.CreateDirectory("wwwroot/img/product/");
                    foreach (var formFile in _form.Files)
                    {
                        if (formFile.Length > 0)
                        {
                            var filePath = "wwwroot/img/product/" + formFile.FileName;
                            using (var stream = new FileStream(filePath, FileMode.Create)) // Mở stream để lưu file, lưu file ở thư mục wwwroot/upload/
                            {
                                formFile.CopyTo(stream);
                            }

                            var imgPath = "/img/product/" + formFile.FileName;

                            var product = _myDatabase.Products.Where(p => p.Id == id).FirstOrDefault();
                            product.Name = model.Name;
                            product.Price = model.Price;
                            product.Count = model.Count;
                            product.Desc = model.Desc;
                            product.Image = imgPath;

                            _myDatabase.Products.Update(product);
                            _myDatabase.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _myDatabase.Products.Where(p => p.Id == id).FirstOrDefault();
            _myDatabase.Products.Remove(product);
            _myDatabase.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _myDatabase.Products.Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }
    }
}
