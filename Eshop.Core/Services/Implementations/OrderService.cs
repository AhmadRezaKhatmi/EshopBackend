using Eshop.Core.DTOs.Orders;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Common;
using Eshop.Data.Entities.Orders;
using Eshop.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Services.Implementations
{
    public class OrderService : IOrderService
    {
        #region Constructor

        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public OrderService(
            IGenericRepository<Order> orderRepository,
            IGenericRepository<OrderDetail> orderDetailRepository,
            IUserService userService,
            IProductService productService)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _userService = userService;
            _productService = productService;
        }

        #endregion


        #region Order
        public Order CreateUserOrder(long userId)
        {
            var order = new Order
            {
                UserId = userId,
                IsPay = false
            };

            _orderRepository.AddEntity(order);
            _orderRepository.SaveChanges();

            return order;

        }

        public Order GetUserOpenOrder(long userId)
        {
            var order = _orderRepository.GetEntitiesQuery().
                Include(s=>s.OrderDetails).
                ThenInclude(s=>s.Product).
                SingleOrDefault(o => o.UserId == userId && o.IsPay != null);

            if (order == null)
                CreateUserOrder(userId);

            return order;

        }

        #endregion


        #region Order Detail

        public void AddProductToOrder(long userId, long productId, int count)
        {
            var user = _userService.GetUserByUserId(userId);

            var product = _productService.GetProductById(productId);

            if (user != null && product != null)
            {
                var order = GetUserOpenOrder(userId);

                //Count
                if (count < 1) count = 1;

                var details = GetOrderDetails(order.Id);

                var existsDetail = details.SingleOrDefault(s => s.ProductId == productId);

                if (existsDetail != null)
                {
                    existsDetail.Count += count;
                    _orderDetailRepository.UpdateEntity(existsDetail);
                }
                else
                {
                    var detail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = productId,
                        Count = count,
                        Price = product.Price
                    };
                     _orderDetailRepository.AddEntity(detail);
                }

                 _orderDetailRepository.SaveChanges();

            }

        }

        public List<OrderDetail> GetOrderDetails(long orderId) 
        {
            return _orderDetailRepository.GetEntitiesQuery().
                Where(od => od.OrderId == orderId).
                ToList();
        }


        public List<OrderBasketDetail> GetUserBasketDetails(long userId)
        {
            var openOrder = GetUserOpenOrder(userId);

            if (openOrder == null) 
                return null;

            var x = openOrder.OrderDetails;

            return openOrder.OrderDetails.Select(f => new OrderBasketDetail
            {
                Count = f.Count,
                Price = f.Price,
                Title = f.Product.ProductName,
                ImageName = PathTools.Domain + PathTools.ProductImagePath + f.Product.ImageName
            }).ToList();
        }

        public void DeleteOrderDetail(OrderDetail Detail)
        {
            _orderDetailRepository.RemoveEntity(Detail);
            _orderDetailRepository.SaveChanges();
        }

        #endregion
    }
}
