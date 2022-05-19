using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class GeographicBoundary
    {
        public int GeographicBoundaryId { get; set; }
        public string GeographicCode { get; set; } = null!;
        public string GeographicBoundaryName { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
    }
}
