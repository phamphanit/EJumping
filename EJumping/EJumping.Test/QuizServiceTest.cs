
using EJumping.BLL.QuizService;
using EJumping.DAL.EF.Entities;
using EJumping.DAL.Repository;
using EJumping.DAL.UnitOfWork;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EJumping.Test
{
   
    public class QuizServiceTest
    {
        private readonly Mock<IRepository<Question>> mockQuizRepository;
        private readonly Mock<IUnitOfWork> unitOfWork;
        private readonly Mock<IQuizService> quizService;
        private readonly Mock<ejumpingContext> ejumpingContext;

        public QuizServiceTest(Mock<IRepository<Question>> mockQuizRepository,Mock<IUnitOfWork> unitOfWork)
        {
            this.mockQuizRepository = mockQuizRepository;
            this.unitOfWork = unitOfWork;
            //this.quizService = new QuizService(mockQuizRepository.Object, unitOfWork.Object);
        }
        [Fact]
        public void Shoud_GetQuestions_Success()
        {
            var mockList = new List<Question>
            {
                new Question
                {
                    Id = 1
                }

            };
            var quizServicee = new QuizService(mockQuizRepository.Object, unitOfWork.Object, ejumpingContext.Object);

            //mockQuizRepository.Setup(x => x.dbSet).Returns(mockList);
            int totalCount;
            var result = quizServicee.GetQuestions(1,5,1,out totalCount);


        }
    }
}
