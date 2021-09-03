using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJumping.BLL.QuizService;
using EJumping.DAL.EF.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EJumping.Api.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizService quizService;
        private readonly ILogger<QuizController> logger;

        public QuizController(IQuizService quizService,ILogger<QuizController> logger)
        {
            this.quizService = quizService;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/api/quiz/{type}")]
        public IActionResult GetQuestion(int type, int pageSize = 5, int page = 1)
        {
            try
            {
                int totalCount;
                var data = this.quizService.GetQuestions(type, pageSize, page, out totalCount);
                if (data.Count() == 10)
                {
                this.logger.LogInformation("Can't load");
                this.logger.LogError("Errorrrrrrrrrrrrr");
                    throw new ApplicationException("Failed to load 10 questions");
                }
                return this.Ok(new ListResult<Question>
                {
                    Page = page,
                    PageSize = pageSize,
                    Items = data,
                    TotalCount = totalCount
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
