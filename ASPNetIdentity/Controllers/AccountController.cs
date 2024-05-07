using ASPNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login2(string email, string password)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            if(user != null)
            {
                //var test = _signInManager.SignOutAsync();
                var result = _signInManager.PasswordSignInAsync(user, password, false, false).Result;
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }
    }
}
