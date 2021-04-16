using AutoMapper;
using EJumping.Core.Models.User;
using EJumping.DAL.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJumping.BLL.User
{
    public class UserService : IUserService
    {
        private readonly ejumpingContext context;
        private readonly IMapper mapper;

        public UserService(ejumpingContext context,IMapper mapper )
        {
            this.context = context;
            this.mapper = mapper;
        }
        public UserDetail GetFullUserById(long userId)
        {
            var user = this.context.Users.Include(x => x.UserRole).Single(u => u.Id == userId);
            var mappedUser = this.mapper.Map<UserDetail>(user);
            mappedUser.IsSiteAdmin = user.UserRole != null && user.UserRole.Any(x => x.RoleId == 1);
            return mappedUser;
        }
    }
}
