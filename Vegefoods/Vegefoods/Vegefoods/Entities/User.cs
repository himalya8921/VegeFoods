using System;
using System.Collections.Generic;

#nullable disable

namespace Vegefoods.Entities
{
    public partial class User
    {
        public User()
        {
            UserCarts = new HashSet<UserCart>();
            UserWishlists = new HashSet<UserWishlist>();
        }

        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public virtual ICollection<UserCart> UserCarts { get; set; }
        public virtual ICollection<UserWishlist> UserWishlists { get; set; }
    }
}
