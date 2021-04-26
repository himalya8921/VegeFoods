using System;
using System.Collections.Generic;

#nullable disable

namespace Vegefoods.Entities
{
    public partial class Product
    {
        public Product()
        {
            UserCarts = new HashSet<UserCart>();
            UserWishlists = new HashSet<UserWishlist>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductRating { get; set; }
        public long AvailableQuantity { get; set; }
        public string ProductImage { get; set; }

        public virtual ICollection<UserCart> UserCarts { get; set; }
        public virtual ICollection<UserWishlist> UserWishlists { get; set; }
    }
}
