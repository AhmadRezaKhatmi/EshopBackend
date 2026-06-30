using Eshop.Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Entities.Product
{
    public class ProductCategory : BaseEntity
    {
        #region Properties

        public string Title { get; set; }

        public long? ParentId { get; set; } //نداریم ! پس می تواند نال باشد Parent در لایه اول که هیچ 

        #endregion



        #region Relations


        [ForeignKey("ParentId")]
        public ProductCategory ParentCategory { get; set; }


        public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }


        #endregion

    }
}
