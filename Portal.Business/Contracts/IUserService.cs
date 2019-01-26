using Portal.Domain.ViewModels;
using Portal.Business.Contracts.Base;

namespace Portal.Business.Contracts
{
    public interface IUserService : IFetch<ViewModelInternalUser>, IFind<ViewModelInternalUser>
    {
    }
}