using ManagementPermission.Domain.Entities;
using ManagementPermission.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ManagementPermission.Persistence.Seed
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ManagementPermissionDbContext(serviceProvider.GetRequiredService<DbContextOptions<ManagementPermissionDbContext>>()))
            {
                if (context.TypeOfPermission.Any())
                {
                    return;
                }

                context.TypeOfPermission.AddRange(
                    new TypeOfPermission
                    {
                        Description = "Disease"
                    },

                    new TypeOfPermission
                    {
                        Description = "Obligation"
                    },


                    new TypeOfPermission
                    {
                        Description = "Holidays"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
