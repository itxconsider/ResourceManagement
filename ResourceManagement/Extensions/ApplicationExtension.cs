using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceManagement.Database;
using System.Reflection;

namespace ResourceManagement.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {            
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            services.AddAutoMapper(Assembly.GetEntryAssembly());
            services.Configure<JsonOptions>(options =>
            {
                options.JsonSerializerOptions.IncludeFields = true;
            });
            return services;
        }
    }
}
