using ASPNetIdentity.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPNetIdentity.InfraStructures.Requirment
{
    public class AuditRequirmentHandler : AuthorizationHandler<AuditRequirment>
    {
        protected override Task HandleRequirementAsync(
                                            AuthorizationHandlerContext context, 
                                            AuditRequirment requirement)
        {
            var entity = context.Resource as BaseEntity;

            //Find User By Name
            var userId = 2;//مثال
            if (entity.AddBy == userId)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
