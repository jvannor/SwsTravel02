﻿using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
