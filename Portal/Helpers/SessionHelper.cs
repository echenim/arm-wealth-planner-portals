using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Business.Contracts;
using Portal.Business.Utilities;

namespace Portal.Helpers
{
    public class SessionHelper
    {
        private readonly HttpContext _context;
        private readonly ICartManager _cartManager;
        private const string SessionName = "_ArmTracker";

        public SessionHelper(HttpContext context)
        {
            // _cartManager = cartManager;
            _context = context;
        }

        public string UserSessionTracker()
        {
            if (_context.Session.GetString(SessionName) == null)
            {
                //var trnx = new Generators(_cartManager).GetTrnxNo();
                //var newTracker = Guid.NewGuid().ToString().Replace("-", "");
                //  _context.Session.SetString(SessionName, trnx.ToString());
            };

            return _context.Session.GetString(SessionName);
        }
    }
}