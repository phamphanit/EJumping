using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EJumping.Api;
using EJumping.Api.Filters;
using EJumping.Api.Hubs;
using EJumping.Application;
using EJumping.Application.EmailMessages.DTOs;
using EJumping.BLL;
using EJumping.BLL.QuizService;
using EJumping.BLL.UserService;
using EJumping.Core.Models.Configurations;
using EJumping.Core.Models.User;
using EJumping.DAL.EF.Entities;
using EJumping.DAL.Repository;
using EJumping.DAL.UnitOfWork;
using EJumping.Infrastructure.MessageBrokers;
using EJumping.Persistence;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EJumping.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
            AppSettings = new EJumpingWebConfiguration();
        }
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        private EJumpingWebConfiguration AppSettings { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Config Serilog
            Log.Logger = new LoggerConfiguration()
                  .ReadFrom.Configuration(this.Configuration)
                  .CreateLogger();

            //Config Database
            services.AddPersistence(Configuration.GetConnectionString("DefaultConnection"))
                    .AddIdentity();

            services.AddIdentityServer()
                    .AddAspNetIdentity<ApplicationUser>()
                    .AddDeveloperSigningCredential()
                    .AddIdServerPersistence(Configuration.GetConnectionString("Idsrv"));

            services.AddApplicationServices();

            services.Configure<EJumpingWebConfiguration>(Configuration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(options =>
                  {
                      options.Authority = Configuration["IdentityServerAuthentication:Authority"];
                      options.Audience = Configuration["IdentityServerAuthentication:ApiName"];
                      options.RequireHttpsMetadata = false;
                  });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                //builder.WithOrigins("http://localhost:3000", "https://localhost:3000")               

                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //Auto Mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());

            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSignalR().AddMessagePackProtocol();

            services.AddMessageBusSender<EmailMessageCreatedEvent>(AppSettings.MessageBroker);

            services.AddControllersWithViews();
            services.AddControllers(configure =>
            {
                configure.Filters.Add(typeof(GlobalExceptionFilter));
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("MyPolicy");

            app.UseIdentityServer();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSignalR(routes => routes.MapHub<NotificationHub>("/ejumpingHub"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //>Processing
            var user = await this._userManager.GetUserAsync(context.Subject);

            var roles = await this._userManager.GetRolesAsync(user);

            var claims = new List<Claim>
                {
                    new Claim("ExampleClaimType", "ExampleClaimValue"),
                };

            foreach (var role in roles)
            {
                claims.Add(new Claim("Role", role));
            }

            //if (!string.IsNullOrEmpty(user.ProfileImageUrl))
            //{
            //    claims.Add(new Claim("ProfilePicUrl", user.ProfileImageUrl));
            //}
            //else
            //{
            //    claims.Add(new Claim("ProfilePicUrl", "https://mo2ja.s3.ap-northeast-2.amazonaws.com/Uploads/User/Image/defaultuser.jpg"));
            //}
            claims.Add(new Claim("Username", user.UserName));
            claims.Add(new Claim("Id", user.Id.ToString()));

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            //>Processing
            var user = await this._userManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null);
        }
    }
}
