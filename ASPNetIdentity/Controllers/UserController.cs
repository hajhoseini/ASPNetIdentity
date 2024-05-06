using ASPNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetIdentity.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        // user/CreateUser?username=ali&email=ali@gmail.com&password=123456
        public IActionResult CreateUser(string username, string email, string password)
        {
            var result = _userManager.CreateAsync(new AppUser { UserName = username, Email = email }, password).Result;
            return RedirectToAction("Index");
        }

    }
}
