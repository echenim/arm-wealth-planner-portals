using System.Linq;

namespace PortalAPI.Midleware.Store.Contracts.Base
{
   public interface IQueryableEntity<T> where T:class 
    {
        IQueryable<T> EntitySet { get; }
    }
}
