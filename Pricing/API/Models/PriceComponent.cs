using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class PriceComponent
    {
        public int PriceComponentId { get; set; }
        public int PriceComponentTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ThruDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? Percentage { get; set; }
        public string? Comment { get; set; }
        public int? Quantity { get; set; }

        public virtual PriceComponentType PriceComponentType { get; set; } = null!;
    }
}
