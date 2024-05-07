using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetIdentity.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var list = roleManager.Roles.ToList();

            return View(list);
        }

        //https://localhost:7148/role/createrole/?name=admin
        public IActionResult CreateRole(string name)
        {
            var result = roleManager.CreateAsync(new IdentityRole { Name = name }).Result;
            
            return View("Index");
        }
    }
}
