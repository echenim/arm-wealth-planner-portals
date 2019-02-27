using Portal.Business.Contracts.Base;
using Portal.Business.Utilities;
using Portal.Domain.Models;

namespace Portal.Business.Contracts
{
    public interface IPersonManager : IFind<Person>, IFetch<Person>, IDelete<Person>
    {
        NotificationResult<Person> Save(Person model);

        NotificationResult<Person> Edit(Person model);
    }
}