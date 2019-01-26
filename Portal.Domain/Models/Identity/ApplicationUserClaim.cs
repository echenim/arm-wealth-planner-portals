using Microsoft.AspNetCore.Identity;

namespace Portal.Domain.Models.Identity
{
    public   class ApplicationUserClaim: IdentityUserClaim<long>
    {
        public ApplicationUserClaim():base()
        {

        }
    }
}
