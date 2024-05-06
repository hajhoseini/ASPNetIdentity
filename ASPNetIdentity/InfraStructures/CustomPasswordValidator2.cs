using ASPNetIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace ASPNetIdentity.InfraStructures
{
    public class CustomPasswordValidator2 : PasswordValidator<AppUser>
    {
        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var result = base.ValidateAsync(manager, user, password).Result;

            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Password cannot contain username"
                });
            }
            if (password.Contains("12345"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSequence",
                    Description = "Password cannot contain numeric sequence"
                });
            }
            return Task.FromResult(errors.Count == 0 ? IdentityResult.Success :
                                                        IdentityResult.Failed(errors.ToArray())
                                    );
        }
    }
}
