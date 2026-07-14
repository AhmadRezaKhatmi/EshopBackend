using Eshop.Core.DTOs.Products;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Common;
using Eshop.Core.Utilities.Extensions.Identity;
using Eshop.Data.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{

    public class ProductsController : SiteBaseController
    {

        #region Constructor

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion



        #region Products

        [HttpGet("filter-products")]
        public IActionResult GetProducts([FromQuery] FilterProductsDTO filter)
        {
            var products = _productService.FilterProducts(filter);


            return JsonResponseStatus.Success(products);
        }

        #endregion



        #region Products Categories

        [HttpGet("product-active-categories")]
        public IActionResult GetProductsCategories()
        {
            var productsCategories = _productService.GetAllActiveProductCategories();


            return JsonResponseStatus.Success(productsCategories);
        }

        #endregion


        #region Get Single Product

        [HttpGet("single-product/{id}")]
        public IActionResult GetProduct(long id)
        {
            var product = _productService.GetProductById(id);

            var productGalleries = _productService.GetProductActiveGalleries(id);

            if (product != null)
                return JsonResponseStatus.Success(new
                {
                    product = product,
                    galleries = productGalleries
                });

            return JsonResponseStatus.NotFound();
        }

        #endregion



        #region  Related Products

        [HttpGet("related-products/{id}")]
        public IActionResult GetRelatedProducts(long id)
        {
            var relatedProducts = _productService.GetRelatedProducts(id);

            return JsonResponseStatus.Success(relatedProducts);
        }

        #endregion


        #region Product Comments

        [HttpGet("product-comments/{id}")]
        public IActionResult GetProductComments(long id)
        {
            var comments = _productService.GetProductActiveComments(id);

            return JsonResponseStatus.Success(comments);

        }


        [HttpPost("add-product-comment")]
        public IActionResult AddProductComment([FromBody] AddProductCommentDTO comment)
        {
            //Check IsAuthenticated
            if (!User.Identity.IsAuthenticated)
                return JsonResponseStatus.Error(new { message = "لطفا ابتدا وارد سایت شوید" });

            //Check Product Exists
            var product = _productService.GetProductById(comment.ProductId);

            if (product == null)
                return JsonResponseStatus.NotFound();

            //Get UserId
            var userId = User.GetUserId();

            //Add Product Comment
            var res = _productService.AddCommentToProduct(comment, userId);

            return JsonResponseStatus.Success(res);
        }

        #endregion


    }
}
