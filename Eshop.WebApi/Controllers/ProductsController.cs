using Eshop.Core.DTOs.Products;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Common;
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
            var productsCategories=_productService.GetAllActiveProductCategories();


            return JsonResponseStatus.Success(productsCategories);
        }

        #endregion
    }
}
