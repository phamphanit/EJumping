using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJumping.BLL.Quiz;
using EJumping.DAL.EF.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpGet]
        [Route("/api/quiz/{type}")]
        public IActionResult GetQuestion(int type, int pageSize = 5, int page = 1)
        {
            int totalCount;
            var data = this.quizService.GetQuestions(type, pageSize, page,out totalCount);
            return this.Ok( new ListResult<Question>
            {
               Page= page,
               PageSize = pageSize,
               Items = data,
               TotalCount = totalCount
            });
        }
    }
    public class ListResult<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
