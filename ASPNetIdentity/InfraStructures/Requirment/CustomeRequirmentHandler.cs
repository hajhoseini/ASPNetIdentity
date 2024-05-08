using Microsoft.AspNetCore.Authorization;

namespace ASPNetIdentity.InfraStructures.Requirment
{
    public class CustomeRequirmentHandler : AuthorizationHandler<CustomeRequirment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomeRequirment requirement)
        {
            //عملیات موردنظر
            return Task.CompletedTask;
        }
    }
}
