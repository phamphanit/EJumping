using EJumping.DAL.EF.Entities;
using EJumping.Domain.Repositories;
using EJumping.Persistence;
using EJumping.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString, string migrationsAssembly = "")
        {
            services.AddDbContext<ejumpingDbContext>(options => options.UseNpgsql(connectionString, sql =>
            {
                if (!string.IsNullOrEmpty(migrationsAssembly))
                {
                    sql.MigrationsAssembly(migrationsAssembly);
                }
            }))
                .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
                .AddScoped(typeof(IUnitOfWork), services =>
                {
                    return services.GetRequiredService<ejumpingDbContext>();
                });
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString, sql =>
            {
                if (!string.IsNullOrEmpty(migrationsAssembly))
                {
                    sql.MigrationsAssembly(migrationsAssembly);
                }
            }));
            return services;
        }

        public static void MigrateAdsDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<ejumpingDbContext>().Database.Migrate();
            }
        }
    }
}
