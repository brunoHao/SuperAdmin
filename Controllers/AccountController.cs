using DemoWebTemplate.ExtendMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Org.BouncyCastle.Bcpg.OpenPgp;
using SuperAdmin.Models;
using SuperAdmin.Models.Account;
using SuperAdmin.Utilities;

namespace SuperAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        [TempData]
        public string StatusMessage { get; set; }

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.UserNameOrEmail, model.Password, model.RememberMe, lockoutOnFailure: true);
                // Tìm UserName theo Email, đăng nhập lại
                if ((!result.Succeeded) && AppUtilities.IsValidEmail(model.UserNameOrEmail))
                {
                    var user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
                    if (user != null)
                    {
                        result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);
                        StatusMessage = "Success";
                        return RedirectToAction("Index", "Home", StatusMessage);

                    }
                }

                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    StatusMessage = "Success";
                    return RedirectToAction("Index", "Home", StatusMessage);
                }


                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "Your Account Are Locked");
                    StatusMessage = "Your Account Are Locked";
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError("Cannot SignIn.");
                    StatusMessage = "Cannot SignIn";
                    return View(model);
                }
            }
            return View(model);
        }


        public IActionResult Logout()
        {
            return View();
        }
    }
}
