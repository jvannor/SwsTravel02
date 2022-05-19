using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class ProductCategoryClassification
    {
        public int ProductCategoryId { get; set; }
        public int TravelProductId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
        public string? Comments { get; set; }
        public bool PrimaryFlag { get; set; }
    }
}
