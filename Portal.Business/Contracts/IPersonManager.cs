using Portal.Business.Contracts.Base;
using Portal.Domain.Models;

namespace Portal.Business.Contracts
{
    public interface IPersonManager : ICreate<Person>, IEdit<Person>, IFind<Person>, IFetch<Person>, IDelete<Person>
    {
    }
}