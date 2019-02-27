using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.Utilities
{
    public class NotificationResult<T> where T : class
    {
        public bool Succeed { get; set; }
        public T TObj { get; set; }
    }
}