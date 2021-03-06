using System;
using System.Collections.Generic;

#nullable disable

namespace Vegefoods.Entities
{
    public partial class UserCart
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
