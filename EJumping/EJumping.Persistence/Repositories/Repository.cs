using EJumping.CrossCuttingConcerns.OS;
using EJumping.Domain.Entities;
using EJumping.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EJumping.Persistence.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey>
        where T : AggregateRoot<TKey>
    {
        protected readonly DbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        public IQueryable<T> DbSet
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }
        //public IUnitOfWork UnitOfWork
        //{
        //    get
        //    {
        //        return _dbContext;
        //    }
        //}
        public Repository(ejumpingDbContext dbContext, IDateTimeProvider dateTimeProvider)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task AddOrUpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity.Id.Equals(default(TKey)))
            {
                entity.CreatedDateTime = _dateTimeProvider.OffsetNow;
                await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            }
            else
            {
                entity.UpdatedDateTime = _dateTimeProvider.OffsetNow;
            }
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public Task<T1> FirstOrDefaultAsync<T1>(IQueryable<T1> query)
        {
            return query.FirstOrDefaultAsync();
        }

        public Task<T1> SingleOrDefaultAsync<T1>(IQueryable<T1> query)
        {
            return query.SingleOrDefaultAsync();
        }

        public Task<List<T1>> ToListAsync<T1>(IQueryable<T1> query)
        {
            return query.ToListAsync();
        }
    }
}
