using Microsoft.AspNetCore.Identity;

namespace Portal.Domain.Models.Identity
{
    public class ApplicationRoleClaim : IdentityRoleClaim<long>
    {
        public ApplicationRoleClaim() : base()
        {

        }
    }
}
