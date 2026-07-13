using Eshop.Core.DTOs.Products;
using Eshop.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Services.Interfaces
{
    public interface IProductService : IDisposable
    {

        #region Product

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        FilterProductsDTO FilterProducts(FilterProductsDTO filter);

        Product GetProductById(long productId);

        #endregion



        #region Product Categories

        List<ProductCategory> GetAllActiveProductCategories();

        #endregion
    }
}
