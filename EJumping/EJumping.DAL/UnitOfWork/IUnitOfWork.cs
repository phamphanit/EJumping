using System;
using System.Collections.Generic;
using System.Text;
using EJumping.DAL.EF.Entities;
using EJumping.DAL.Repository;

namespace EJumping.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<EJumping.DAL.EF.Entities.Quiz> Questions { get; }
        void Commit();
    }
}
