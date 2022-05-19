using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class ScheduledTransportationOffering
    {
        public int FixedAssetId { get; set; }
        public int TravelProductId { get; set; }
        public int ScheduledTransportationId { get; set; }
        public int ScheduledTransportationOfferingId { get; set; }
        public DateTime FromDate { get; set; }
        public int Quantity { get; set; }
        public DateTime ThruDate { get; set; }

        public virtual ScheduledTransportation ScheduledTransportation { get; set; } = null!;
    }
}
