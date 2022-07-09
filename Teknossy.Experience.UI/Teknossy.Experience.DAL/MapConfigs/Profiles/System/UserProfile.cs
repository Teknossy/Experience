using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Experience.DTO.Results.System;
using Teknossy.Experience.DTO.Params.System;
using Teknossy.Experience.Entity.Models.System;

namespace Teknossy.Experience.DAL.MapConfigs.Profiles.System
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PmUser, User>();
            CreateMap<User, RsUser>();
        }
    }
}
