using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EJumping.DAL.EF.Entities
{
    public class Question
    {
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public string FirstOption { get; set; }

        public string SecondOption { get; set; }

        public string ThirdOption { get; set; }

        public string FourthOption { get; set; }

        public int CorrectAnswer { get; set; }

        public int CorrectAnswerPoints { get; set; }

        public int QuizId { get; set; }

        //[ConcurrencyCheck]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[NotMapped]
        //public byte[] Timestamp { get; set; }
        //[ConcurrencyCheck]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[NotMapped]
        public uint xmin { get; set; }
        public Quiz Quiz { get; set; }
    }
}
