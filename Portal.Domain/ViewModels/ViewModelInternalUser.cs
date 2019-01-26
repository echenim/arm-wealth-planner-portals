using System;

namespace Portal.Domain.ViewModels
{
    public class ViewModelInternalUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}