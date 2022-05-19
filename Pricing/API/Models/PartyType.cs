using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class PartyType
    {
        public int PartyTypeId { get; set; }
        public string Description { get; set; } = null!;
    }
}
