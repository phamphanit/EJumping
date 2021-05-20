using DbUp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EJumping.Migrator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddIdentityServer()
                .AddIdServerPersistence(Configuration.GetConnectionString("Idsrv"),
                typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Policy.Handle<Exception>().WaitAndRetry(new[]
            {
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(20),
                TimeSpan.FromSeconds(30),
            })
            .Execute(() =>
            {
                app.MigrateIdServerDb();

                //var upgrader = DeployChanges.To
                //.SqlDatabase(Configuration.GetConnectionString("Idsrv"))
                //.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                //.LogToConsole()
                //.Build();

                //var result = upgrader.PerformUpgrade();

                //if (!result.Successful)
                //{
                //    throw result.Error;
                //}
            });
        }
    }
}
