﻿namespace Portal.Business.ViewModels
{
    public class ArmOneAuthTokenRequest : BaseRequest 
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }
}
