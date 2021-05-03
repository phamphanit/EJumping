using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJumping.BLL.Quiz;
using Microsoft.AspNetCore.Mvc;

namespace EJumping.Api.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizService quizService;

        public QuizController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        public IActionResult GetQuestion(int type, int pageSize = 5, int pageNumber = 1)
        {
            int totalCount;
            var data = this.quizService.GetQuestions(type, pageSize, pageNumber,out totalCount);
            return this.Ok(data);
        }
    }
}
