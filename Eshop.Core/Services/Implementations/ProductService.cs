using Eshop.Core.DTOs.Paging;
using Eshop.Core.DTOs.Products;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Extensions.Paging;
using Eshop.Data.Entities.Product;
using Eshop.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Eshop.Core.DTOs.Products.FilterProductsDTO;

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
        private readonly IGenericRepository<ProductComment> _productCommentRepository;

        public ProductService(IGenericRepository<Product> ProductRepository,
                              IGenericRepository<ProductCategory> ProductCategoryRepository,
                              IGenericRepository<ProductGallery> ProductGalleryRepository,
                              IGenericRepository<ProductSelectedCategory> ProductSelectedCategoryRepository,
                              IGenericRepository<ProductVisit> ProductVisitRepository,
                              IGenericRepository<ProductComment> productCommentRepository)
        {
            _productRepository = ProductRepository;
            _productCategoryRepository = ProductCategoryRepository;
            _productGalleryRepository = ProductGalleryRepository;
            _productVisitRepository = ProductVisitRepository;
            _productSelectedCategoryRepository = ProductSelectedCategoryRepository;
            _productCommentRepository = productCommentRepository;
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


        public Product GetProductById(long productId)
        {
            return _productRepository.GetEntityById(productId);
        }


        public List<Product> GetRelatedProducts(long productId)
        {
            //Get Product
            var product = _productRepository.GetEntityById(productId);

            //If Is Null Return Null
            if (product == null)
                return null;

            var productCategoriesList = _productSelectedCategoryRepository.GetEntitiesQuery().
                Where(x => x.ProductId == productId).Select(c => c.ProductCategoryId);

            var relatedProducts = _productRepository.GetEntitiesQuery().
                SelectMany(s => s.ProductSelectedCategories.
                Where(f => productCategoriesList.Contains(f.ProductCategoryId)).
                Select(t => t.Product)).
                Where(s => s.Id != productId).
                OrderByDescending(s => s.CreateDate).
                Take(4).
                ToList();

            return relatedProducts;
        }

        public FilterProductsDTO FilterProducts(FilterProductsDTO filter)
        {
            //Base Query
            var productsQuery = _productRepository.GetEntitiesQuery().AsQueryable();


            //Order By
            switch (filter.OrderBy)
            {
                case ProductOrderBy.PriceAsc:
                    productsQuery = productsQuery.OrderBy(x => x.Price);
                    break;
                case ProductOrderBy.PriceDec:
                    productsQuery = productsQuery.OrderByDescending(x => x.Price);
                    break;
            }


            //Filter Title
            if (!string.IsNullOrEmpty(filter.Title))
                productsQuery = productsQuery.Where(s => s.ProductName.Contains(filter.Title));


            //Filter StartPrice
            if (filter.StartPrice != 0)
                productsQuery = productsQuery.Where(s => s.Price >= filter.StartPrice);


            //Filter EndPrice
            if (filter.EndPrice != 0)
                productsQuery = productsQuery.Where(s => s.Price <= filter.EndPrice);


            //Filter ProductCategoryIds
            if (filter.Categories != null && filter.Categories.Any())
                productsQuery = productsQuery.
                    SelectMany(s => s.ProductSelectedCategories.
                    Where(f => filter.Categories.Contains(f.ProductCategoryId)).
                    Select(t => t.Product));


            //Filter EndPrice
            if (filter.EndPrice != 0)
                productsQuery = productsQuery.Where(s => s.Price <= filter.EndPrice);

            //Paging
            var count = (int)Math.Ceiling(productsQuery.Count() / (double)filter.TakeEntity);

            var pager = Pager.Build(count, filter.PageId, filter.TakeEntity);

            var products = productsQuery.Paging(pager).ToList();

            //Return Final Result
            return filter.SetProducts(products).SetPaging(pager);
        }

        #endregion


        #region Product Categories

        public List<ProductCategory> GetAllActiveProductCategories()
        {
            return _productCategoryRepository.GetEntitiesQuery().Where(item => !item.IsDelete).ToList();
        }

        #endregion


        #region Product Galleries

        public List<ProductGallery> GetProductActiveGalleries(long productId)
        {
            return _productGalleryRepository.GetEntitiesQuery().
                Where(x => x.ProductId == productId && x.IsDelete == false).
                Select(s => new ProductGallery
                {
                    ProductId = s.ProductId,
                    Id = productId,
                    ImageName = s.ImageName,
                    CreateDate = s.CreateDate
                }).
                ToList();
        }

        #endregion

        #region Product Comments

        public ProductCommentDTO AddCommentToProduct(AddProductCommentDTO comment, long userId)
        {
            var productComment = new ProductComment
            {
                UserId = userId,
                ProductId = comment.ProductId,
                Text = comment.Text,    
            };

            _productCommentRepository.AddEntity(productComment);
            _productCommentRepository.SaveChanges();

            return new ProductCommentDTO
            {
                Id = productComment.Id,
                CreateDate = productComment.CreateDate.ToString("yyyy/MM/dd HH:mm"),
                Text = productComment.Text,
                UserId = userId,
                UserFullName = ""
            };

        }

        public List<ProductCommentDTO> GetProductActiveComments(long productId)
        {
            var productComments = _productCommentRepository
            .GetEntitiesQuery()
            .Include(s => s.User)
            .Where(c => c.ProductId == productId && !c.IsDelete)
            .OrderByDescending(s => s.CreateDate)
            .Select(s => new ProductCommentDTO
            {
                Id = s.Id,
                Text = s.Text,
                UserId = s.UserId,
                UserFullName = s.User.FirstName + " " + s.User.LastName,
                CreateDate = s.CreateDate.ToString("yyyy/MM/dd HH:mm")
            }).ToList();

            return productComments;
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
