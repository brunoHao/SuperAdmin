using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperAdmin.Models;
using SuperAdmin.Models.Shop;

namespace SuperAdmin.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly MyDatabase _myDatabase;
        public OrderController(
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
            var orDers = _myDatabase.Orders.ToList();
            return View(orDers);
        }

        public ActionResult Details(int id)
        {
            Order ord = _myDatabase.Orders.Find(id);
            var Ord_details = _myDatabase.OrderDetails.Where(x => x.OrderID == id).ToList();
            var tuple = new Tuple<Order, IEnumerable<OrderDetails>>(ord, Ord_details);

            double SumAmount = Convert.ToDouble(Ord_details.Sum(x => x.TotalAmount));
            ViewBag.TotalItems = Ord_details.Sum(x => x.Quantity);
            ViewBag.Discount = 0;
            ViewBag.TAmount = SumAmount - 0;
            ViewBag.Amount = SumAmount;
            return View(tuple);
        }
    }
}
