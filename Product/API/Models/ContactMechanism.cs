using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class ContactMechanism
    {
        public int ContactMechanismId { get; set; }
        public string ContactMechanismName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
