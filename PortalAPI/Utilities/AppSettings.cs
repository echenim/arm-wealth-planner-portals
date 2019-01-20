using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.Utilities
{
    public class AppSettings
    {
        public AppSettings()
        {
            Secret = "";
        }

        public string Secret { get; set; }
    }
}