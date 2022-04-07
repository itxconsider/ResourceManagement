using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceManagement.Database;
using ResourceManagement.Repositories;
using System.Reflection;

namespace ResourceManagement.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {            
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            services.AddAutoMapper(Assembly.GetEntryAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddLazyCache();
            services.Configure<JsonOptions>(options =>
            {
                options.JsonSerializerOptions.IncludeFields = true;
            });
            services.AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
                .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>)); 
            
            return services;
        }
    }
}
