using ASPNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            if (result.Succeeded)
                return RedirectToAction("Index");
            else
                return View();
        }

        public IActionResult DeleteUser(string username)
        {
            var user = _userManager.FindByNameAsync(username).Result;
            var deleteresult = _userManager.DeleteAsync(user).Result;

            return RedirectToAction("Index");
        }

        public IActionResult AddRole(string email, string role)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            if(user != null)
            {
                var result = _userManager.AddToRoleAsync(user, role).Result;
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult AddClaim(string email)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user != null)
            {
                var claim = new Claim("HireDate", DateTime.Now.AddYears(-5).ToString());

                var result = _userManager.AddClaimAsync(user, claim).Result;
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
