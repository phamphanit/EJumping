using EJumping.Domain.DTOs;
using EJumping.Domain.Entities;
using EJumping.Domain.Repositories;
using EJumping.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJumping.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User, Guid> _userRepository;
        private readonly IUnitOfWork _uow;
        public UserService(
            IRepository<User,Guid> userRepository,
            IUnitOfWork uow
            )
        {
            _userRepository = userRepository;
            _uow = uow;
        }
        public  GetByIdUserDto GetUserById(Guid id)
        {
            var user =  _userRepository.DbSet.Where(x => x.Id == id).FirstOrDefault();

            var userDtos = new GetByIdUserDto
            {
                UserName = user.UserName,
                Email = user.Email
            };

            return userDtos;
        }
    }
}
