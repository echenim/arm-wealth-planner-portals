using Portal.Business.Contracts.Base;
using Portal.Domain.Models;

namespace Portal.Business.Contracts
{
    public interface IProductKeyBenefitService : ICreate<ProductKeyBenefit>, IEdit<ProductKeyBenefit>,
        IFind<ProductKeyBenefit>, IFetch<ProductKeyBenefit>, IDelete<ProductKeyBenefit>
    {
    }
}