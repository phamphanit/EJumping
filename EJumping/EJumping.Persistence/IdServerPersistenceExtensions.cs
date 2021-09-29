using System.Collections.Generic;
using System.Linq;
using EJumping.Core.ExtensionMethods;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdServerPersistenceExtensions
    {
        public static IIdentityServerBuilder AddIdServerPersistence(this IIdentityServerBuilder services, string connectionString, string migrationsAssembly = "")
        {
            services.AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = builder =>
                    builder.UseNpgsql(connectionString,
                        sql =>
                        {
                            if (!string.IsNullOrEmpty(migrationsAssembly))
                            {
                                sql.MigrationsAssembly(migrationsAssembly);
                            }
                        });
                options.DefaultSchema = "idsv";
            })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseNpgsql(connectionString,
                            sql =>
                            {
                                if (!string.IsNullOrEmpty(migrationsAssembly))
                                {
                                    sql.MigrationsAssembly(migrationsAssembly);
                                }
                            });
                    options.DefaultSchema = "idsv";

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30; // interval in seconds
                });
            return services;
        }

        public static void MigrateIdServerDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                var clients = new List<Client>();

                if (!context.Clients.Any(x => x.ClientId == "Swagger"))
                {
                    clients.Add(new Client
                    {
                        ClientId = "Swagger",
                        ClientName = "Swagger",
                        AllowedGrantTypes = GrantTypes.Code,
                        RequirePkce = true,
                        RedirectUris =
                        {
                            "https://localhost:44312/oauth2-redirect.html",
                            "http://host.docker.internal:9002/oauth2-redirect.html",
                        },
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "EJumping.WebAPI",
                        },
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256()),
                        },
                        RequireConsent = false,
                    });
                }
                if (!context.Clients.Any(x => x.ClientId == "EJumping.WebApi"))
                {
                    clients.Add(new Client
                    {
                        ClientId = "EJumping.WebApi",
                        ClientName = "EJumping Web Api",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        RequirePkce = true,
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "EJumping.WebAPI",
                        },
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256()),
                        },
                        AllowOfflineAccess = true,
                        RequireConsent = true,
                        AccessTokenLifetime = 36000,
                    });
                }
                if (!context.Clients.Any(x => x.ClientId == "EJumping.WebMVC"))
                {
                    clients.Add(new Client
                    {
                        ClientId = "EJumping.WebMVC",
                        ClientName = "EJumping Web MVC",
                        AllowedGrantTypes = GrantTypes.Code.Combines(GrantTypes.ResourceOwnerPassword),
                        RequirePkce = true,
                        RedirectUris =
                        {
                            "https://localhost:44352/signin-oidc",
                            "http://host.docker.internal:9003/signin-oidc",
                        },
                        PostLogoutRedirectUris =
                        {
                            "https://localhost:44352/signout-callback-oidc",
                            "http://host.docker.internal:9003/signout-callback-oidc",
                        },
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "EJumping.WebAPI",
                        },
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256()),
                        },
                        AllowOfflineAccess = true,
                        RequireConsent = true,
                        AccessTokenLifetime = 36000,
                    });
                }

                if (!context.Clients.Any(x => x.ClientId == "EJumping.React"))
                {
                    clients.Add(new Client
                    {
                        ClientId = "EJumping.React",
                        ClientName = "EJumping React",
                        AllowedGrantTypes = GrantTypes.Code,
                        RequireClientSecret = false,
                        RequirePkce = true,
                        AllowAccessTokensViaBrowser = true,
                        RedirectUris =
                        {
                            "http://localhost:3000/oidc-login-redirect",
                        },
                        PostLogoutRedirectUris =
                        {
                            "http://localhost:3000/?postLogout=true",
                        },
                        AllowedCorsOrigins =
                        {
                            "http://localhost:3000",
                        },
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "EJumping.WebAPI",
                        },
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256()),
                        },
                        AllowOfflineAccess = true,
                        RequireConsent = true,
                        AccessTokenLifetime = 36000,
                    });
                }

                if (clients.Any())
                {
                    context.Clients.AddRange(clients.Select(x => x.ToEntity()));
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    var identityResources = new List<IdentityResource>()
                    {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                    };

                    context.IdentityResources.AddRange(identityResources.Select(x => x.ToEntity()));

                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    var apiScopes = new List<ApiScope>()
                    {
                        new ApiScope("EJumping.WebAPI", "EJumping Web API"),
                    };

                    context.ApiScopes.AddRange(apiScopes.Select(x => x.ToEntity()));
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    var apiResources = new List<ApiResource>
                    {
                        new ApiResource("EJumping.WebAPI", "EJumping Web API", new[] { "role" })
                        {
                            Scopes = { "EJumping.WebAPI" },
                        },
                    };

                    context.ApiResources.AddRange(apiResources.Select(x => x.ToEntity()));

                    context.SaveChanges();
                }
            }
        }
    }
}
