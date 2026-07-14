using Eshop.Data.Entities.Account;
using Eshop.Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Entities.Orders
{
    public class Order : BaseEntity
    {
        #region Properties

        public long UserId { get; set; }

        public bool IsPay {  get; set; }

        public DateTime? PaymentDate { get; set; }  

        #endregion



        #region Relations

        public User User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion

    }
}
