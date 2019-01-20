using PortalAPI.Midleware.Contracts.Base;
using PortalAPI.Domain.Models;

namespace PortalAPI.Midleware.Contracts
{
    public interface IPersonService : ICreate<Person>, IEdit<Person>, IFind<Person>, IFetch<Person>, IDelete<Person>
    {
    }
}