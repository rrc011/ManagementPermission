using ManagementPermission.Application.Interfaces;
using ManagementPermission.Application.Interfaces.Repositories;
using ManagementPermission.Persistence.Context;
using ManagementPermission.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementPermission.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
              services.AddDbContext<ManagementPermissionDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ManagementPermissionDbContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<ITypeOfPermissionRepository, TypeOfPermissionRepository>();
            #endregion
        }
    }
}
