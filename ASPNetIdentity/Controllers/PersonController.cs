using ASPNetIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetIdentity.Controllers
{
    public class PersonController : Controller
    {
        private readonly IAuthorizationService authorizationService;

        public PersonController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var person = new Person
            {
                AddBy = 1,
                AddDate = new DateTime(2018, 01, 12),
                Id = 3,
                Name = "Masoud Amiri"
            };
            var result = authorizationService.AuthorizeAsync(User, person, "AuditRequirment").Result;
            if (result.Succeeded)
            {

            }
            return Challenge();
        }
    }
}
