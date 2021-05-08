using AutoMapper;
using EJumping.Core.Models.Quiz;
using EJumping.DAL.EF.Entities;
using EJumping.DAL.Repository;
using EJumping.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJumping.BLL.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly IRepository<Question> quizRepository;
        private readonly IUnitOfWork unitOfWork;
        public QuizService(IRepository<Question> quizRepository, IUnitOfWork unitOfWork)
        {
            this.quizRepository = quizRepository;
            this.unitOfWork = unitOfWork;
        }
        public List<Question> GetQuestions(int type, int pageSize, int page, out int totalCount)
        {
            var query = quizRepository.dbSet.Where(x => x.QuizId == type);
            var question = query.Skip(pageSize * (1 - page)).Take(pageSize).ToList();
            totalCount = query.Count();
            return question;
        }
    }
}
