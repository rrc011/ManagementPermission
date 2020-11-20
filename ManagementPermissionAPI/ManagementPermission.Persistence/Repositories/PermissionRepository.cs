using ManagementPermission.Application.Interfaces.Repositories;
using ManagementPermission.Domain.Entities;
using ManagementPermission.Persistence.Context;

namespace ManagementPermission.Persistence.Repositories
{
    public class PermissionRepository : GenericRepositoryAsync<Permission>, IPermissionRepository
    {
        public PermissionRepository(ManagementPermissionDbContext dbContext) : base(dbContext)
        {
        }
    }
}
