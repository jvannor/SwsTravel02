using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class Organization
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; } = null!;
    }
}
