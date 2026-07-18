using Eshop.Core.DTOs.Orders;
using Eshop.Data.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Services.Interfaces
{
    public interface IOrderService
    {
        #region Order
        Order CreateUserOrder(long userId);

        Order GetUserOpenOrder(long userId);

        #endregion

        #region Order Detail

        void AddProductToOrder(long userId, long productId, int count);
        List<OrderDetail> GetOrderDetails(long orderId);

        List<OrderBasketDetail> GetUserBasketDetails(long userId);

        void DeleteOrderDetail(OrderDetail Detail);
        #endregion
    }
}
