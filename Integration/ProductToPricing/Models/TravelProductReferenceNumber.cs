using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class TravelProductReferenceNumber
    {
        public string TravelProductReferenceNumberId { get; set; } = null!;
        public int TravelProductId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }

        public virtual TravelProduct TravelProduct { get; set; } = null!;
    }
}
