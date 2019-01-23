using System.Threading.Tasks;

namespace PortalAPI.Midleware.BaseStore.Contracts.Base
{
    public interface IGetById<T> where T : class
    {
        T GetById(object id);

        Task<T> GetByIdAsync(object id);
    }
}