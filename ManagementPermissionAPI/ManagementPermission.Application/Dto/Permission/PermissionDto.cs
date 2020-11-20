using ManagementPermission.Application.Common;
using ManagementPermission.Application.Dto.TypeOfPermission;
using System;

namespace ManagementPermission.Application.Dto.Permission
{
    public class PermissionDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public int TypeOfPermissionId { get; set; }
        public TypeOfPermissionDto TypeOfPermission { get; set; }
    }
}
