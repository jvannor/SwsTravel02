using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class UnitOfMeasureType
    {
        public UnitOfMeasureType()
        {
            UnitOfMeasures = new HashSet<UnitOfMeasure>();
        }

        public int UnitOfMeasureTypeId { get; set; }
        public string UnitOfMeasureTypeName { get; set; } = null!;

        public virtual ICollection<UnitOfMeasure> UnitOfMeasures { get; set; }
    }
}
