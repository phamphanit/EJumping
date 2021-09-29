using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJumping.Domain.DTOs;
using EJumping.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EJumping.Api.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuestionService questionService;
        private readonly ILogger<QuizController> logger;

        public QuizController(IQuestionService quizService,ILogger<QuizController> logger)
        {
            this.questionService = quizService;
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
                var data = this.questionService.GetQuestions(type, pageSize, page, out totalCount);

                return this.Ok(new ListResult<QuestionDto>
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
