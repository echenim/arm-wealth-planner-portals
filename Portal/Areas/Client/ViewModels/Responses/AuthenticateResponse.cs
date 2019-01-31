using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class AuthenticateResponse
    {
        public int MembershipKey { get; set; }
        public string AltUsername { get; set; }
        public string OldPortfolioNo { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public bool IsActive { get; set; }
        public bool IsSysGenerated { get; set; }
        public bool IsTcAgreed { get; set; }
        public bool IsIndemnityAgreed { get; set; }
        public string ResponseMessage { get; set; }
    }
}
