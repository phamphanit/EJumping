using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EJumping.Api;
using EJumping.BLL;
using EJumping.BLL.QuizService;
using EJumping.BLL.UserService;
using EJumping.Core.Models.Configurations;
using EJumping.Core.Models.User;
using EJumping.DAL.EF.Entities;
using EJumping.DAL.Repository;
using EJumping.DAL.UnitOfWork;
using IdentityServer4.Models;
using IdentityServer4.Services;
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
        }
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Config Serilog
            Log.Logger = new LoggerConfiguration()
                  .ReadFrom.Configuration(this.Configuration)
                  .CreateLogger();

            //Config Database
            services.AddDbContext<ejumpingContext>(options =>
                options.UseNpgsql(
                  Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(
                  Configuration.GetConnectionString("DefaultConnection")));

            //Config Asp.net Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.AllowedUserNameCharacters = null;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 10;
            })
             //.AddErrorDescriber<LocalizedIdentityErrorDescriber>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();


            //Config IdentityServer4
            var builder = services.AddIdentityServer()
               .AddAspNetIdentity<ApplicationUser>()
               .AddInMemoryIdentityResources(Config.IdentityResources)
               .AddInMemoryApiResources(Config.ApiResource)
               .AddInMemoryApiScopes(Config.Scopes)
               .AddInMemoryClients(Config.Clients)
               .AddProfileService<ProfileService>()
               ;

            // this adds the config data from DB (clients, resources)
            //.AddConfigurationStore(options =>
            //{
            //    options.ConfigureDbContext = b =>
            //        b.UseNpgsql(connectionStringIdsvr4,
            //            sql => sql.MigrationsAssembly(migrationsAssembly));
            //})
            //// this adds the operational data from DB (codes, tokens, consents)
            //.AddOperationalStore(options =>
            //{
            //    options.ConfigureDbContext = b =>
            //        b.UseNpgsql(connectionStringIdsvr4,
            //            sql => sql.MigrationsAssembly(migrationsAssembly));

            //     // this enables automatic token cleanup. this is optional.
            //     options.EnableTokenCleanup = true;
            //})
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                //options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = null;

                // Require confirmed email, should be enabled later ?
                //options.SignIn.RequireConfirmedEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Cookie.Name = "ejumping.identity";
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                // options.LoginPath = "/Account/Login";
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;

            });
            services.Configure<EJumpingWebConfiguration>(Configuration.GetSection("EJumpingWebConfiguration"));

            builder.AddDeveloperSigningCredential();
            services.AddAuthentication("Bearer")
               .AddIdentityServerAuthentication(options =>
               {
                   options.Authority = Configuration["EJumpingWebConfiguration:IdSrvUrl"];
                   if (Environment.IsDevelopment())
                   {
                       options.RequireHttpsMetadata = false;
                   }
                   options.ApiSecret = "secret";
                   options.ApiName = "api1";
               })
               .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                //builder.WithOrigins("http://localhost:3000", "https://localhost:3000")               

                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddScoped<DbContext, ejumpingContext>();
            services.AddScoped<IUserService, UserService>();


            //Auto Mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());

            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository<Question>, BaseRepository<Question>>();
            services.AddScoped<IQuizService,QuizService>();
            services.AddControllersWithViews();
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

            if (!string.IsNullOrEmpty(user.ProfileImageUrl))
            {
                claims.Add(new Claim("ProfilePicUrl", user.ProfileImageUrl));
            }
            else
            {
                claims.Add(new Claim("ProfilePicUrl", "https://mo2ja.s3.ap-northeast-2.amazonaws.com/Uploads/User/Image/defaultuser.jpg"));
            }
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
