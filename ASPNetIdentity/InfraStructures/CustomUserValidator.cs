using ASPNetIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace ASPNetIdentity.InfraStructures
{
    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (!user.Email.EndsWith("@nikamooz.com"))
            {
                errors.Add(new IdentityError
                {
                    Code = "InvalidEmail",
                    Description = "Use Organization Email"
                });
            }
            return Task.FromResult(errors.Count == 0 ?
           IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
