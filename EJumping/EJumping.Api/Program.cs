using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJumping.Api.ConfigurationOptions;
using EJumping.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EJumping.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseSerilog((context, services, configuration) => configuration
                //    .ReadFrom.Configuration(context.Configuration)
                //    .ReadFrom.Services(services)
                //    .Enrich.FromLogContext()
                //    //.WriteTo.Console())
                //    .WriteTo.File("Logs/log.txt"))

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseGlobalLogger(configuration =>
                    //{
                    //    var appSettings = new AppSettings();
                    //    configuration.Bind(appSettings);
                    //    return appSettings.Logging;
                    //});
                    webBuilder.UseSerilog();
                });
        
            
    }
}
