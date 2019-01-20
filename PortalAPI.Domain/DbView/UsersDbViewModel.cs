namespace PortalAPI.Domain.DbView
{
    public class UsersDbViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Classification { get; set; }
        public string Organization { get; set; }
        public bool iSPermissionGranted { get; set; }
        public int NumberOfFailedSignedIn { get; set; }
    }
}