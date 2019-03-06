using System.Linq;
using Portal.Business.Contracts.Base;
using Portal.Domain.Models;

namespace Portal.Business.Contracts
{
    public interface IProductManager : ICreate<Products>, IEdit<Products>,
        IFind<Products>, IFetch<Products>, IDelete<Products>, ICreate<WhatYouNeedToKNowAboutThisProduct>,
        IEdit<WhatYouNeedToKNowAboutThisProduct>, ICreate<ProductInvestmentInfo>, IEdit<ProductInvestmentInfo>

    {
        IQueryable<WhatYouNeedToKNowAboutThisProduct> Get(int productId);

        IQueryable<ProductInvestmentInfo> GetInvestmentInfo(int productsId);
    }
}