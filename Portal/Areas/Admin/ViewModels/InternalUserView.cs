using System;

namespace Portal.Areas.Admin.ViewModels
{
    public class InternalUserView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
    }
}