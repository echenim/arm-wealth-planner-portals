using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.ViewModels
{
    public class AssignUserToGroupView
    {
        public long UserId { get; set; }
        public string[] groupname { get; set; }
    }
}