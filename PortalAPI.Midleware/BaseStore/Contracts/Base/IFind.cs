using System.Threading.Tasks;

namespace PortalAPI.Midleware.BaseStore.Contracts.Base
{
    public interface IFind<T> where T : class
    {
        Task<T> FindByNameAsync(string name);

        T FindByName(string name);
    }
}