using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
