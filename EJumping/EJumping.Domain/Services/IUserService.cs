using EJumping.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Domain.Services
{
    public interface IUserService
    {
        GetByIdUserDto GetUserById(Guid id);
    }
}
