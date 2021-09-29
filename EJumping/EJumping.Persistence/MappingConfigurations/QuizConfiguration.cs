using EJumping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EJumping.Persistence.MappingConfigurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable("Quizs");
            builder.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v1()");
            builder.HasData(
                new Quiz
                {
                    Id = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F660"),
                    Name = "Ielts",

                },
                new Quiz
                {
                    Id = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    Name = "Toeic"
                }
                );
        }
    }
}
