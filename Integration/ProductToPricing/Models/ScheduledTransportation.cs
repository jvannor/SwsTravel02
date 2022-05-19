using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class ScheduledTransportation
    {
        public ScheduledTransportation()
        {
            ScheduledTransportationOfferings = new HashSet<ScheduledTransportationOffering>();
        }

        public int FixedAssetId { get; set; }
        public int TravelProductId { get; set; }
        public int ScheduledTransportationId { get; set; }
        public int PartyId { get; set; }
        public int OrganizationRoleTypeId { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? DepartureTime { get; set; }

        public virtual FixedAsset FixedAsset { get; set; } = null!;
        public virtual OrganizationRole OrganizationRole { get; set; } = null!;
        public virtual TravelProduct TravelProduct { get; set; } = null!;
        public virtual ICollection<ScheduledTransportationOffering> ScheduledTransportationOfferings { get; set; }
    }
}
