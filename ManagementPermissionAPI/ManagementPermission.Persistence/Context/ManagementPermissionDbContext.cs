using ManagementPermission.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementPermission.Persistence.Context
{
    public class ManagementPermissionDbContext : DbContext
    {
        public ManagementPermissionDbContext(DbContextOptions<ManagementPermissionDbContext> options)
            :base(options)
        {

        }

        public DbSet<Permission> Permission { get; set; }
        public DbSet<TypeOfPermission> TypeOfPermission { get; set; }
    }
}
