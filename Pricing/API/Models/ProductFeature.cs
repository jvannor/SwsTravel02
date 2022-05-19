using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class ProductFeature
    {
        public int ProductFeatureId { get; set; }
        public string Description { get; set; } = null!;
    }
}
