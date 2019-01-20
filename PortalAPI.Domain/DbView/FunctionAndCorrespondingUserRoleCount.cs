using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Domain.DbView
{
    public class FunctionAndCorrespondingUserRoleCount
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string NumberOfUser { get; set; }
        public string NumberOfRole { get; set; }
    }
}