using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementPermission.Application.Common
{
    public class BaseUpdateEntityDto
    {
        public int Id { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
