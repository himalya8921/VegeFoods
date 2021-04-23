using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VegeFoodsEntities.Entities
{
    public partial class Users
    {
        public Users()
        {
            UserCart = new HashSet<UserCart>();
            UserWishlist = new HashSet<UserWishlist>();
        }

        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserCart> UserCart { get; set; }
        public virtual ICollection<UserWishlist> UserWishlist { get; set; }
    }
}
