using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationDateTime { get; set; }

        public DateTime ModificationDateTime { get; set; }

    }
}
