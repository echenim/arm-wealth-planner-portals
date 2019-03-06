using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Business.Contracts;
using Portal.ViewModel;

namespace Portal.Helpers
{
    public class RenderProductViewHelper
    {
        private readonly IProductManager _productManager;

        public RenderProductViewHelper(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public ProductsAndProductsItem Get(string productCategoryName, int productId)
        {
            var data = _productManager.Get(s => s.ProductCategory.Name.Equals(productCategoryName));

            var itebData = new List<ProductsAndItems>();
            foreach (var item in data)
            {
                itebData.Add(new ProductsAndItems
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            var viewData = new ProductsAndProductsItem();
            viewData.ProductsObj = _productManager.Get(s => s.Id == productId).SingleOrDefault();
            viewData.Items = itebData;

            return viewData;
        }
    }
}