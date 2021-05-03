using EJumping.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.BLL.Quiz
{
    public interface IQuizService
    {
        List<Question> GetQuestions(int type, int pageSize, int page,out int totalCount);
    }
}
