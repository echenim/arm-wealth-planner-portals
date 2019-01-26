using Portal.Business.Contracts.Base;
using Portal.Domain.Models;

namespace Portal.Business.Contracts
{
    public interface IPersonService : ICreate<Person>, IEdit<Person>, IFind<Person>, IFetch<Person>, IDelete<Person>
    {
    }
}