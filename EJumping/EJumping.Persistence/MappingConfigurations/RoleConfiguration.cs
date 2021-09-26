using EJumping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EJumping.Persistence.MappingConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v1()");

            builder.HasMany(x => x.Claims)
                .WithOne(x => x.Role)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.UserRoles)
                .WithOne(x => x.Role)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
