using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class OrganizationRole
    {
        public OrganizationRole()
        {
            FixedAssets = new HashSet<FixedAsset>();
            ScheduledTransportations = new HashSet<ScheduledTransportation>();
        }

        public int PartyId { get; set; }
        public int OrganizationRoleTypeId { get; set; }

        public virtual OrganizationRoleType OrganizationRoleType { get; set; } = null!;
        public virtual ICollection<FixedAsset> FixedAssets { get; set; }
        public virtual ICollection<ScheduledTransportation> ScheduledTransportations { get; set; }
    }
}
