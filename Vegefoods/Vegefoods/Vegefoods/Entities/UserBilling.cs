using System;
using System.Collections.Generic;

#nullable disable

namespace Vegefoods.Entities
{
    public partial class UserBilling
    {
        public long BillingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string StreetAddress { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public long? TotalBill { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
