using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VegeFoodsEntities.CustomEntities
{
    public class UserWishlistModel
    {
        [Key]
        public long ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public long ProductPrice { get; set; }




    }
}
