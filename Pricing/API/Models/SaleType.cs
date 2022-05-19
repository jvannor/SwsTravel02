using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class SaleType
    {
        public int SaleTypeId { get; set; }
        public string Description { get; set; } = null!;
    }
}
