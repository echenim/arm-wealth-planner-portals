using PortalAPI.Domain.DbView;
using PortalAPI.Midleware.Store.Contracts.Base;

namespace PortalAPI.Midleware.Store.Contracts
{
    internal interface IFunctionAndCorrespondingUserRoleCountBase : IEntitySet<FunctionAndCorrespondingUserRoleCount>, IQueryableEntity<FunctionAndCorrespondingUserRoleCount>, IGetById<FunctionAndCorrespondingUserRoleCount>, IFind<FunctionAndCorrespondingUserRoleCount>
    {
    }
}