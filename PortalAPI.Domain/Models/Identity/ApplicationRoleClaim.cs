using Microsoft.AspNetCore.Identity;

namespace PortalAPI.Domain.Models.Identity
{
    public class ApplicationRoleClaim : IdentityRoleClaim<long>
    {
        public ApplicationRoleClaim() : base()
        {

        }
    }
}
