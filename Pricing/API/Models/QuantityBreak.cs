using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class QuantityBreak
    {
        public int QuantityBreakId { get; set; }
        public int FromQuantity { get; set; }
        public int? ThruQuantity { get; set; }
    }
}
