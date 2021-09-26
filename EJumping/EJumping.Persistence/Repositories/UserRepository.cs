using EJumping.CrossCuttingConcerns.OS;
using EJumping.Domain.Entities;
using EJumping.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EJumping.Persistence.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(ejumpingDbContext dbContext, IDateTimeProvider dateTimeProvider)
            : base(dbContext, dateTimeProvider)
        {
        }

        public IQueryable<User> Get(UserQueryOptions queryOptions)
        {
            var query = GetAll();
            if (queryOptions.IncludeTokens)
            {
                query = query.Include(x => x.Tokens);
            }

            if (queryOptions.IncludeClaims)
            {
                query = query.Include(x => x.Claims);
            }

            if (queryOptions.IncludeUserRoles)
            {
                query = query.Include(x => x.UserRoles);
            }

            if (queryOptions.IncludeRoles)
            {
                query = query.Include("UserRoles.Role");
            }

            if (queryOptions.AsNoTracking)
            {
                query = query = query.AsNoTracking();
            }

            return query;
        }
    }
}
