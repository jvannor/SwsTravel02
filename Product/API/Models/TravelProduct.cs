using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class TravelProduct
    {
        public TravelProduct()
        {
            FixedAssets = new HashSet<FixedAsset>();
            RegularlyScheduledTimes = new HashSet<RegularlyScheduledTime>();
            ScheduledTransportations = new HashSet<ScheduledTransportation>();
            TravelProductReferenceNumbers = new HashSet<TravelProductReferenceNumber>();
            TravelProductIdFors = new HashSet<TravelProduct>();
            TravelProductIdOfs = new HashSet<TravelProduct>();
        }

        public int TravelProductId { get; set; }
        public int TravelProductTypeId { get; set; }
        public string TravelProductName { get; set; } = null!;
        public string? Description { get; set; }
        public int? FacilityIdGoingTo { get; set; }
        public int? FacilityIdOriginatingFrom { get; set; }
        public virtual Facility? FacilityIdGoingToNavigation { get; set; }

        public virtual Facility? FacilityIdOriginatingFromNavigation { get; set; }

        public virtual TravelProductType? TravelProductType { get; set; } = null!;

        public virtual ICollection<FixedAsset> FixedAssets { get; set; }

        public virtual ICollection<RegularlyScheduledTime> RegularlyScheduledTimes { get; set; }

        public virtual ICollection<ScheduledTransportation> ScheduledTransportations { get; set; }

        public virtual ICollection<TravelProductReferenceNumber> TravelProductReferenceNumbers { get; set; }

        public virtual ICollection<TravelProduct> TravelProductIdFors { get; set; }

        public virtual ICollection<TravelProduct> TravelProductIdOfs { get; set; }
    }
}
