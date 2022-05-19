using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class OrderValue
    {
        public int OrderValueId { get; set; }
        public int FromAmount { get; set; }
        public int? ThruAmount { get; set; }
    }
}
