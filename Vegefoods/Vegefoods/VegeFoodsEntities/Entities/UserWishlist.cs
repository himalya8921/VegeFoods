using System;
using System.Collections.Generic;

#nullable disable

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
