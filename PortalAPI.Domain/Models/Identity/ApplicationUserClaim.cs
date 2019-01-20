using Microsoft.AspNetCore.Identity;

namespace PortalAPI.Domain.Models.Identity
{
    public   class ApplicationUserClaim: IdentityUserClaim<long>
    {
        public ApplicationUserClaim():base()
        {

        }
    }
}
