using ManagementPermission.Application.Common;
using System;

namespace ManagementPermission.Application.Dto.Permission
{
    public class UpdatePermissionDto : BaseUpdateEntityDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public int TypeOfPermissionId { get; set; }
    }
}
