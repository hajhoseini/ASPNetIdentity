using Microsoft.AspNetCore.Authorization;

namespace ASPNetIdentity.InfraStructures.Requirment
{
    public class CustomeRequirment : IAuthorizationRequirement
    {
        public string Name { get; set; }
    }
}
