using System;
using System.Linq;

namespace PortalAPI.Midleware.Contracts.Base
{
    public interface IFetch<T> where T : class
    {
        IQueryable<T> Get(Func<T, bool> predicate = null);
    }
}