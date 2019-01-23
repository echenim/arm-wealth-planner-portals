using System.Linq;

namespace PortalAPI.Midleware.BaseStore.Contracts.Base
{
    public interface IQueryableEntity<T> where T : class
    {
        IQueryable<T> EntitySet { get; }
    }
}