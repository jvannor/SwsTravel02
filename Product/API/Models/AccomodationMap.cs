using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class AccomodationMap
    {
        public int AccomodationMapTypeId { get; set; }
        public int AccomodationClassId { get; set; }
        public int FixedAssetId { get; set; }
        public int NumberOfSpaces { get; set; }

        public virtual AccomodationClass AccomodationClass { get; set; } = null!;
        public virtual AccomodationMapType AccomodationMapType { get; set; } = null!;
        public virtual FixedAsset FixedAsset { get; set; } = null!;
    }
}
