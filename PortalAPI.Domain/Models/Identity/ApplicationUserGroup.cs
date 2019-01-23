using System.Collections.Generic;

namespace PortalAPI.Domain.Models.Identity
{
    public class ApplicationUserGroup
    {
        public long ApplicationUserId { get; set; }
        public long ApplicationGroupId { get; set; }
    }
}