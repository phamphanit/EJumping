using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Domain.DTOs
{
    public class QuestionDto
    {
        public string QuestionName { get; set; }

        public string FirstOption { get; set; }

        public string SecondOption { get; set; }

        public string ThirdOption { get; set; }

        public string FourthOption { get; set; }

        public int CorrectAnswer { get; set; }

        public int CorrectAnswerPoints { get; set; }

        public Guid QuizId { get; set; }
    }
}
