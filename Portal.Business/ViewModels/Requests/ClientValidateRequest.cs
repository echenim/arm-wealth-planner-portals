using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class ClientValidateRequest : BaseRequest
    {
        public string CustomerReference { get; set; }
    }
}
