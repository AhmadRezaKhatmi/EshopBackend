using Eshop.Core.DTOs.Paging;
using Eshop.Core.DTOs.Products;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Extensions.Paging;
using Eshop.Data.Entities.Product;
using Eshop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Services.Implementations
{
    public class ProductService : IProductService
    {
        #region Constructor

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IGenericRepository<ProductGallery> _productGalleryRepository;
        private readonly IGenericRepository<ProductSelectedCategory> _productSelectedCategoryRepository;
        private readonly IGenericRepository<ProductVisit> _productVisitRepository;

        public ProductService(IGenericRepository<Product> ProductRepository,
                              IGenericRepository<ProductCategory> ProductCategoryRepository,
                              IGenericRepository<ProductGallery> ProductGalleryRepository,
                              IGenericRepository<ProductSelectedCategory> ProductSelectedCategoryRepository,
                              IGenericRepository<ProductVisit> ProductVisitRepository)
        {
            _productRepository = ProductRepository;
            _productCategoryRepository = ProductCategoryRepository;
            _productGalleryRepository = ProductGalleryRepository;
            _productVisitRepository = ProductVisitRepository;
            _productSelectedCategoryRepository = ProductSelectedCategoryRepository;
        }

        #endregion

        #region Product

        public void AddProduct(Product product)
        {
            _productRepository.AddEntity(product);
            _productRepository.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateEntity(product);
            _productRepository.SaveChanges();
        }

        public FilterProductsDTO FilterProducts(FilterProductsDTO filter)
        {
            //Base Query
            var productsQuery = _productRepository.GetEntitiesQuery().AsQueryable();

            //Filter Title
            if (!string.IsNullOrEmpty(filter.Title))
                productsQuery = productsQuery.Where(s => s.ProductName.Contains(filter.Title));


            //Filter StartPrice
            productsQuery = productsQuery.Where(s => s.Price >= filter.StartPrice);


            //Filter EndPrice
            if (filter.EndPrice != 0)
                productsQuery = productsQuery.Where(s => s.Price <= filter.EndPrice);

            //Paging
            var count = (int)Math.Ceiling(productsQuery.Count() / (double)filter.TakeEntity);

            var pager = Pager.Build(count, filter.PageId, filter.TakeEntity);

            var products =productsQuery.Paging(pager).ToList();

            return filter.SetProducts(products).SetPaging(pager);
        }

        #endregion


        #region Dispose
        public void Dispose()
        {
            _productRepository.Dispose();
            _productCategoryRepository.Dispose();
            _productGalleryRepository.Dispose();
            _productVisitRepository.Dispose();
            _productSelectedCategoryRepository.Dispose();
        }


        #endregion
    }
}
