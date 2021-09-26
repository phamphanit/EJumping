using EJumping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EJumping.Persistence.MappingConfigurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable("Quizs");
            builder.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v1()");
        }
    }
}
