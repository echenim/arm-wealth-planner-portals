using System.Threading.Tasks;

namespace PortalAPI.Midleware.Store.Contracts.Base
{
   public interface IFind<T> where T:class
   {
       Task<T> FindByNameAsync(string name);

        T FindByName(string name);
    }
}
