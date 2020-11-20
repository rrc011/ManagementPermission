using ManagementPermission.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementPermission.Domain.Entities
{
    public class Permission : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public int TypeOfPermissionId { get; set; }
        public virtual TypeOfPermission TypeOfPermission { get; set; }
    }
}
