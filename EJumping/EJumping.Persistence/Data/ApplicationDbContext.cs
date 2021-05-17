
using System;
using System.Collections.Generic;
using System.Text;
using EJumping.Core.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EJumping.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<ApplicationUser>().ToTable("AspUsers");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "users");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserName).HasColumnName("user_name");
                entity.Property(e => e.NormalizedUserName).HasColumnName("normalized_user_name");
                entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.NormalizedEmail).HasColumnName("normalized_email");
                entity.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");
                entity.Property(e => e.ProfileImageUrl).HasColumnName("profile_image_url");
                entity.Property(e => e.PreferredLanguage).HasColumnName("preferred_language");
                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
                entity.Property(e => e.Gender).HasColumnName("gender");
                entity.Property(e => e.BirthDate).HasColumnName("birth_date");

                // entity.Property(e => e.ReferrerId).HasColumnName("referrer_id");
                entity.Property(e => e.TwoFactorEnabled).HasColumnName("two_factor_enabled");
                entity.Property(e => e.SecurityStamp).HasColumnName("security_stamp");
                entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");
                entity.Property(e => e.EmailMarketing).HasColumnName("email_marketing");
                entity.Property(e => e.EmailServiceNotification).HasColumnName("email_service_notification");
                entity.Property(e => e.AccessFailedCount).HasColumnName("access_failed_count");
                entity.Property(e => e.LockoutEnabled).HasColumnName("lockout_enabled");
                entity.Property(e => e.LockoutEnd).HasColumnName("lockout_end");
                entity.Property(e => e.VerificationStatus).HasColumnName("verification_status");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.Created).HasColumnName("created");


                // entity.Property(e => e.Id).ValueGeneratedOnAdd();
                //entity.Property(e => e.Id).HasColumnName("UserId");

            });
            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "role");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.NormalizedName).HasColumnName("normalized_name");
                entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");
                //entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.ToTable("user_role");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.RoleId).HasColumnName("role_id");
                //in case you chagned the TKey type
                entity.HasKey(key => new { key.UserId, key.RoleId });
            });

            builder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("user_claim");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.ClaimType).HasColumnName("claim_type");
                entity.Property(e => e.ClaimValue).HasColumnName("claim_value");
            });

            builder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("user_login");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LoginProvider).HasColumnName("login_provider");
                //entity.Property(e => e.ProviderDisplayName).HasColumnName("provider_display_name");
                entity.Property(e => e.ProviderDisplayName).HasColumnName("provider_displayname");
                entity.Property(e => e.ProviderKey).HasColumnName("provider_key");
                //in case you chagned the TKey type
                entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });
            });

            builder.Entity<ApplicationRoleClaim>(entity =>
            {
                entity.ToTable("roleclaim");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.ClaimType).HasColumnName("claim_type");
                entity.Property(e => e.ClaimValue).HasColumnName("claim_value");

            });

            builder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("user_token");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Value).HasColumnName("value");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.LoginProvider).HasColumnName("login_provider");
                //in case you chagned the TKey type
                entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });

            });
        }
    }
}