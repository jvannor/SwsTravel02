using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class FixedAsset
    {
        public FixedAsset()
        {
            AccomodationMaps = new HashSet<AccomodationMap>();
            ScheduledTransportations = new HashSet<ScheduledTransportation>();
        }

        public int FixedAssetId { get; set; }
        public int FixedAssetTypeId { get; set; }
        public string? FixedAssetName { get; set; }
        public int PartyId { get; set; }
        public int OrganizationRoleTypeId { get; set; }
        public DateTime? DateAcquired { get; set; }
        public DateTime? DateLastServiced { get; set; }
        public DateTime? DateNextService { get; set; }
        public decimal? Capacity { get; set; }
        public int? TravelProductId { get; set; }

        public virtual FixedAssetType FixedAssetType { get; set; } = null!;
        public virtual OrganizationRole OrganizationRole { get; set; } = null!;
        public virtual TravelProduct? TravelProduct { get; set; }
        public virtual ICollection<AccomodationMap> AccomodationMaps { get; set; }
        public virtual ICollection<ScheduledTransportation> ScheduledTransportations { get; set; }
    }
}
