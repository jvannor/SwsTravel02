using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class OrganizationRoleType
    {
        public OrganizationRoleType()
        {
            OrganizationRoles = new HashSet<OrganizationRole>();
        }

        public int OrganizationRoleTypeId { get; set; }
        public string? OrganizationRoleName { get; set; }

        public virtual ICollection<OrganizationRole> OrganizationRoles { get; set; }
    }
}
