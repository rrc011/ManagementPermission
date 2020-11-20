using ManagementPermission.Domain.Common;
using System.Collections.Generic;

namespace ManagementPermission.Domain.Entities
{
    public class TypeOfPermission : BaseEntity
    {
        public string Description { get; set; }
        public virtual IEnumerable<Permission> Permission { get; set; }
    }
}
