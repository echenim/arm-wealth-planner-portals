namespace PortalAPI.Domain.Models.Identity
{
    public class ApplicationUserGroup
    {
        //[Key]
        //[ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        //[ForeignKey(nameof(ApplicationGroup))]
        public string ApplicationGroupId { get; set; }

        // public ApplicationUser ApplicationUser { get; set; }
        // public ApplicationGroup ApplicationGroup { get; set; }
    }
}