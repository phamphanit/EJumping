using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EJumping.Domain.Entities
{
    public class Quiz : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public List<Question> QuizQuestions { get; set; }

        public string QuizLogoUrl { get; set; }

    }
}
