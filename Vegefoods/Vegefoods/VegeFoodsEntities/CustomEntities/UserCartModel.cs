using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VegeFoodsEntities.CustomEntities
{
   public class UserCartModel
    {
        [Key]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
       public string ProductImage { get; set; }
        public long ProductPrice { get; set; }
        public long Price { get; set; }
        public long Quantity { get; set; }



    }
}
