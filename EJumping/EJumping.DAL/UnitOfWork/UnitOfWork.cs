using EJumping.DAL.EF.Entities;
using EJumping.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private ejumpingContext _dbContext;
        private BaseRepository<EJumping.DAL.EF.Entities.Quiz> _quiz;

        public UnitOfWork(ejumpingContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IRepository<EJumping.DAL.EF.Entities.Quiz> Questions
        {
            get
            {
                return _quiz ??
                    (_quiz = new BaseRepository<EJumping.DAL.EF.Entities.Quiz>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
