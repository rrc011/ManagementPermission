﻿using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ManagementPermission.Persistence.Repositories
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable) where T : class
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var isVirtual = property.GetGetMethod().IsVirtual;
                if (isVirtual)
                {
                    queryable = queryable.Include(property.Name);
                }
            }
            return queryable;
        }
    }
}
