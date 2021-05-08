using EJumping.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.BLL.UserService
{
    public interface IUserService
    {
        UserDetail GetFullUserById(long userId);
    }
}
