using AutoMapper;
using EJumping.Core.Models.User;
using EJumping.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.BLL
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Users, UserDetail>();
            this.CreateMap<Users, UserPublicDetail>();
        }
    }
}
