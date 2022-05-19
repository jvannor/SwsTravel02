using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Description { get; set; } = null!;
    }
}
