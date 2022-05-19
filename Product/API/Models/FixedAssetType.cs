using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class FixedAssetType
    {
        public FixedAssetType()
        {
            FixedAssets = new HashSet<FixedAsset>();
        }

        public int FixedAssetTypeId { get; set; }
        public string FixedAssetTypeName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<FixedAsset> FixedAssets { get; set; }
    }
}
