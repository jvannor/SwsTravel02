﻿using System;
using System.Collections.Generic;

namespace PricingAPI.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
