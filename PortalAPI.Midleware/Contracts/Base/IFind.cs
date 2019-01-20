using System;

namespace PortalAPI.Midleware.Contracts.Base
{
    public interface IFind<T> where T : class
    {
        T FindById(Func<T, bool> predicate);
    }
}