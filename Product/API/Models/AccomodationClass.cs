using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class AccomodationClass
    {
        public AccomodationClass()
        {
            AccomodationMaps = new HashSet<AccomodationMap>();
        }

        public int AccomodationClassId { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<AccomodationMap> AccomodationMaps { get; set; }
    }
}
