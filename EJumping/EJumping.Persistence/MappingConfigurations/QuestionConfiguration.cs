using EJumping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EJumping.Persistence.MappingConfigurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v1()");
            builder.UseXminAsConcurrencyToken();
            builder.HasData(
                new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "Could you tell me your surname?",
                    FirstOption = "Would you like me to spell it?",
                    SecondOption = "Do you like my family name?",
                    ThirdOption = "How do I say that?",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "This plant looks dead.",
                    FirstOption = "It's in the garden.",
                    SecondOption = "It only needs some water.",
                    ThirdOption = "It's sleeping.",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "I hope it doesn't rain.",
                    FirstOption = "Of course not.",
                    SecondOption = "Will it be wet?",
                    ThirdOption = "So do I.",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "Are you going to come inside soon?",
                    FirstOption = "For ever.",
                    SecondOption = "Not long.",
                    ThirdOption = "In a minute.",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "Who gave you this book, Lucy?",
                    FirstOption = "I bought it.",
                    SecondOption = "For my birthday.",
                    ThirdOption = "My uncle was.",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "Shall we go out for pizza tonight?",
                    FirstOption = "I know that.",
                    SecondOption = "It's very good.",
                    ThirdOption = "I'm too tired.",
                    CorrectAnswer = 1,
                }, new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "Do you mind if I come too?",
                    FirstOption = "That's fine!",
                    SecondOption = "I'd like to.",
                    ThirdOption = "I don't know if I can.",
                    CorrectAnswer = 1,
                }, new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "There's someone at the door.",
                    FirstOption = "Can I help you?",
                    SecondOption = "Well, go and answer it then.",
                    ThirdOption = "He's busy at the moment.",
                    CorrectAnswer = 1,
                }, new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "How much butter do I need for this cake?",
                    FirstOption = "I'd like one.",
                    SecondOption = "I'll use some.",
                    ThirdOption = "I'm not sure.",
                    CorrectAnswer = 1,
                }, new Question
                {
                    Id = Guid.NewGuid(),
                    QuizId = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F661"),
                    QuestionName = "How long are you here for?",
                    FirstOption = "Since last week.",
                    SecondOption = "Ten days ago.",
                    ThirdOption = "Till tomorrow.",
                    CorrectAnswer = 1,
                }
                );
        }
    }
}
