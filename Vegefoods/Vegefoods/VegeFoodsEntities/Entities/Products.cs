using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VegeFoodsEntities.Entities
{
    public partial class Products
    {
        public Products()
        {
            UserCart = new HashSet<UserCart>();
            UserWishlist = new HashSet<UserWishlist>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductRating { get; set; }
        public long AvailableQuantity { get; set; }
        public string ProductImage { get; set; }

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImageUploader { get; set; }

        public virtual ICollection<UserCart> UserCart { get; set; }
        public virtual ICollection<UserWishlist> UserWishlist { get; set; }
    }
}
