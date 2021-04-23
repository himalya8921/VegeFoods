using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VegeFoodsEntities.Entities
{
    public partial class UserWishlist
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public long? Quantity { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
