using EJumping.Domain.DTOs;
using EJumping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Domain.Services
{
    public interface IQuestionService
    {
        List<QuestionDto> GetQuestions(int type, int pageSize, int page, out int totalCount);

    }
}
