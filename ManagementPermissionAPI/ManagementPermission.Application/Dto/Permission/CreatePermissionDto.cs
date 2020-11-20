using ManagementPermission.Application.Common;
using System;

namespace ManagementPermission.Application.Dto.Permission
{
    public class CreatePermissionDto : BaseCreateEntityDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public int TypeOfPermissionId { get; set; }
    }
}
