﻿using AutoMapper;
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
        private readonly ejumpingContext context;

        public QuizService(IRepository<Question> quizRepository, IUnitOfWork unitOfWork, ejumpingContext context)
        {
            this.quizRepository = quizRepository;
            this.unitOfWork = unitOfWork;
            this.context = context;
        }

        public void CreateQuestion()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var question = new Question
                    {
                        QuestionName = "1111",
                        FirstOption = "aaaa",
                        SecondOption = "bbbb",
                        ThirdOption = "Cccc",
                        CorrectAnswer = 1,
                        QuizId = 1
                    };
                    context.Questions.Add(question);
                    context.SaveChanges();
                    //throw new Exception();
                    var question2 = new Question
                    {
                        QuestionName = "22222",
                        FirstOption = "aaaa",
                        SecondOption = "bbbb",
                        ThirdOption = "Cccc",
                        CorrectAnswer = 1,
                        QuizId = 1
                    };
                    context.Questions.Add(question2);

                    var addQuiz3 = context.Questions.Where(x => x.QuestionName == "22222").FirstOrDefault();


                    context.SaveChanges();

                    var addQuiz = context.Questions.Where(x => x.QuestionName == "22222").FirstOrDefault();
                    transaction.Commit();
                    var question3 = new Question
                    {
                        QuestionName = "33333",
                        FirstOption = "aaaa",
                        SecondOption = "bbbb",
                        ThirdOption = "Cccc",
                        CorrectAnswer = 1,
                        QuizId = 1
                    };
                    context.Questions.Add(question3);
                    context.SaveChanges();
                    //throw new Exception();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("error");
                }


            }


        }

        public List<Question> GetQuestions(int type, int pageSize, int page, out int totalCount)
        {
            var query = quizRepository.dbSet.Where(x => x.QuizId == type);
            var question = query.Skip(pageSize * (1 - page)).Take(pageSize).ToList();
            totalCount = query.Count();
            return question;
        }

        public void TestConcurrency()
        {
            Question question1 = null;
            Question question2 = null;


            question1 = context.Questions.Where(x => x.Id == 1).FirstOrDefault();

            question2 = context.Questions.Where(x => x.Id == 1).FirstOrDefault();

            try
            {
                question1.CorrectAnswer = 2;
                context.Entry(question1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                question2.CorrectAnswer = 3;
                context.Entry(question2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void TestConcurrency2()
        {
            Question question1 = null;
            Question question2 = null;

            using (var context = new ejumpingContext())
            {
                question1 = context.Questions.Where(x => x.Id == 1).FirstOrDefault();
            }
            using (var context = new ejumpingContext())
            {
                question2 = context.Questions.Where(x => x.Id == 1).FirstOrDefault();
            }

            using (var context = new ejumpingContext())
            {
                try
                {
                    question1.CorrectAnswer = 2;
                    context.Update(question1);
                    //context.Entry(question1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            using (var context = new ejumpingContext())
            {
                try
                {
                    question2.CorrectAnswer = 3;

                    //context.Entry(question2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.Update(question2);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
