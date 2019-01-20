using PortalAPI.Midleware.Contracts.Base;
using PortalAPI.Domain.Models;

namespace PortalAPI.Midleware.Contracts
{
    public interface IProductKeyBenefitService : ICreate<ProductKeyBenefit>, IEdit<ProductKeyBenefit>,
        IFind<ProductKeyBenefit>, IFetch<ProductKeyBenefit>, IDelete<ProductKeyBenefit>
    {
    }
}