using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class TravelProductType
    {
        public TravelProductType()
        {
            TravelProducts = new HashSet<TravelProduct>();
        }

        public int TravelProductTypeId { get; set; }
        public string TravelProductTypeName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<TravelProduct> TravelProducts { get; set; }
    }
}
