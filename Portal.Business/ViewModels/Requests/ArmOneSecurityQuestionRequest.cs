﻿namespace Portal.Business.ViewModels
{
    public class ArmOneSecurityQuestionRequest : BaseRequest
    {
        public string UserId { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string Channel { get; set; }
    }
}
