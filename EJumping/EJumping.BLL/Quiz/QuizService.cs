using AutoMapper;
using EJumping.Core.Models.Quiz;
using EJumping.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJumping.BLL.Quiz
{
    public class QuizService : IQuizService
    {
        private readonly ejumpingContext context;
        private readonly IMapper mapper;

        public QuizService(ejumpingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Question> GetQuestions(int type, int pageSize, int pageNumber, out int totalCount)
        {
            var query = context.Questions.Where(x => x.QuizId == type);
            var question = query.Skip(pageSize * (1 - pageNumber)).Take(pageSize).ToList();
            totalCount = question.Count();
            return question;
        }
    }
}
