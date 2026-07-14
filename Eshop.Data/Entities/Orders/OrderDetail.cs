using Eshop.Data.Entities.Product;
using Eshop.Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Entities.Orders
{
    public class OrderDetail : BaseEntity
    {
        #region Properties


        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }
        #endregion



        #region Relations

        public Order Order { get; set; }

        public Product.Product Product { get; set; }


        #endregion
    }
}
