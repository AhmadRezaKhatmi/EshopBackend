using Eshop.Data.Entities.Account;
using Eshop.Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Entities.Product
{
    public class ProductComment : BaseEntity
    {
        #region Properties
        public long UserId { get; set; }

        public long ProductId { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Text { get; set; }
        #endregion


        #region Relations

        public Product Product { get; set; }

        public User User { get; set; }

        #endregion

    }
}
