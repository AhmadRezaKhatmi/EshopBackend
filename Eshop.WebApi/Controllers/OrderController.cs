using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Common;
using Eshop.Core.Utilities.Extensions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{

    public class OrderController : SiteBaseController
    {
        #region Constructor

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion


        #region Add Product To Order

        [HttpGet("add-order")]
        public IActionResult AddProductToOrder(long productId, int count)
        {

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.GetUserId();

                _orderService.AddProductToOrder(userId, productId, count);

                return JsonResponseStatus.Success(new { message = "محصول با موفقیت به سبد خرید شما اضافه شد" });
            }

            return JsonResponseStatus.Error(new { message = "برای افزودن محصول به سبد خرید ، ابتدا لاگین کنید" });
        }

        #endregion

    }
}
