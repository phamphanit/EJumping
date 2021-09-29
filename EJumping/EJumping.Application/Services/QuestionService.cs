using EJumping.Domain.DTOs;
using EJumping.Domain.Entities;
using EJumping.Domain.Repositories;
using EJumping.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJumping.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question, Guid> _questionRepo;
        public QuestionService(IRepository<Question, Guid> questionRepo)
        {
            _questionRepo = questionRepo;
        }
        public List<QuestionDto> GetQuestions(int type, int pageSize, int page, out int totalCount)
        {
            var query = _questionRepo.DbSet.AsQueryable();
            var questions = query.Skip(pageSize * (1 - page)).Take(pageSize).Select(x => new QuestionDto
            {
                QuestionName = x.QuestionName,
                CorrectAnswer = x.CorrectAnswer,
                FirstOption = x.FirstOption,
                SecondOption = x.SecondOption,
                ThirdOption = x.ThirdOption,
                FourthOption = x.FourthOption,
                QuizId = x.QuizId,
                CorrectAnswerPoints = x.CorrectAnswerPoints
            }).ToList();
            totalCount = query.Count();
            return questions;
        }
    }
}
