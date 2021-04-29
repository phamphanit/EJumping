using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EJumping.DAL.EF.Entities
{
    public class Quiz
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Question> QuizQuestions { get; set; }

        public string QuizLogoUrl { get; set; }

    }
}
