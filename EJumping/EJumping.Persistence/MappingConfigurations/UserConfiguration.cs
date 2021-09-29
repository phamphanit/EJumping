using EJumping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EJumping.Persistence.MappingConfigurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v1()");

            builder.HasMany(x => x.Claims)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.UserRoles)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
            // builder.Ignore(x => x.CreatedDateTime);


            // Seed
            builder.HasData(new List<User>
            {
                new User
                {
                    Id = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F660"),
                    UserName = "tuser1",
                    NormalizedUserName = "TUSER1",
                    Email = "vincent@gmail.com",
                    NormalizedEmail = "VINCENT@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEI/8CTFnTa2n7lLHSdaBk39FL2LxJdx8cbYBk8LqKvPSdKMcoObbZzXyQvEjLNUNjA==", // 1qaz!QAZ
                    SecurityStamp = "5M2QLL65J6H6VFIS7VZETKXY27KNVVYJ",
                    LockoutEnabled = true,
                },
            });
        }
    }
}
