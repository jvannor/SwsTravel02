using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class PriceComponentType
    {
        public PriceComponentType()
        {
            PriceComponents = new HashSet<PriceComponent>();
        }

        public int PriceComponentTypeId { get; set; }
        public string PriceComponentTypeName { get; set; } = null!;

        public virtual ICollection<PriceComponent> PriceComponents { get; set; }
    }
}
