using ManagementPermission.Application.Interfaces.Repositories;
using ManagementPermission.Domain.Entities;
using ManagementPermission.Persistence.Context;

namespace ManagementPermission.Persistence.Repositories
{
    public class TypeOfPermissionRepository : GenericRepositoryAsync<TypeOfPermission>, ITypeOfPermissionRepository
    {
        public TypeOfPermissionRepository(ManagementPermissionDbContext dbContext) : base(dbContext)
        {
        }
    }
}
