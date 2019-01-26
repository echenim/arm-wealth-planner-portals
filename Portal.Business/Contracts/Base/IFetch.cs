using System;
using System.Linq;

namespace Portal.Business.Contracts.Base
{
    public interface IFetch<T> where T : class
    {
        IQueryable<T> Get(Func<T, bool> predicate = null);
    }
}