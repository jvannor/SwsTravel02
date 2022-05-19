using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class AccomodationMapType
    {
        public AccomodationMapType()
        {
            AccomodationMaps = new HashSet<AccomodationMap>();
        }

        public int AccomodationMapTypeId { get; set; }
        public string AccomodationMapTypeName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<AccomodationMap> AccomodationMaps { get; set; }
    }
}
