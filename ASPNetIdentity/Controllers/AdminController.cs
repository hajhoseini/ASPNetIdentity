using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetIdentity.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //https://localhost:7148/Account/Login?ReturnUrl=%2Fadmin%2Findex
        }
    }
}
