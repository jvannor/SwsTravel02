using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class UnitOfMeasure
    {
        public int UnitOfMeasureId { get; set; }
        public int UnitOfMeasureTypeId { get; set; }
        public string Abbreviation { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual UnitOfMeasureType UnitOfMeasureType { get; set; } = null!;
    }
}
