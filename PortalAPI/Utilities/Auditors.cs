using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace PortalAPI.Utilities
{
    public static class Auditors
    {
        public static void InfoLog(string actionName, string controllerName, string crudAction, string userid, string beforeData, string afterData, string Information)
        {
            Log.Logger.ForContext("Action", actionName)
                .ForContext("Controller", controllerName)
                .ForContext("CRUD_Action", crudAction)
                .ForContext("UserID", userid)
                .ForContext("BeforeData", beforeData)
                .ForContext("AfterData", afterData)
                .Information(Information);
        }
    }
}