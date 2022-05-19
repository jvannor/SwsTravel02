using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class FacilityType
    {
        public FacilityType()
        {
            Facilities = new HashSet<Facility>();
        }

        public int FacilityTypeId { get; set; }
        public string FacilityTypeName { get; set; } = null!;

        public virtual ICollection<Facility> Facilities { get; set; }
    }
}
