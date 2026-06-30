using Eshop.Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Entities.Product
{
    public class ProductSelectedCategory : BaseEntity
    {

        #region Properties

        public long ProductId { get; set; }

        public long ProductCategoryId { get; set; }

        #endregion



        #region Relations

        public Product Product { get; set; }

        public ProductCategory ProductCategory { get; set; }

        #endregion

    }
}
