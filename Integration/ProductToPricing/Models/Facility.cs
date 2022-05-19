using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class Facility
    {
        public Facility()
        {
            InversePartOfFacility = new HashSet<Facility>();
            TravelProductFacilityIdGoingToNavigations = new HashSet<TravelProduct>();
            TravelProductFacilityIdOriginatingFromNavigations = new HashSet<TravelProduct>();
        }

        public int FacilityId { get; set; }
        public int FacilityTypeId { get; set; }
        public string? FacilityName { get; set; }
        public string? Description { get; set; }
        public int? SquareFootage { get; set; }
        public int? PartOfFacilityId { get; set; }
        public int? PartOfFacilityTypeId { get; set; }

        public virtual FacilityType FacilityType { get; set; } = null!;
        public virtual Facility? PartOfFacility { get; set; }
        public virtual ICollection<Facility> InversePartOfFacility { get; set; }
        public virtual ICollection<TravelProduct> TravelProductFacilityIdGoingToNavigations { get; set; }
        public virtual ICollection<TravelProduct> TravelProductFacilityIdOriginatingFromNavigations { get; set; }
    }
}
