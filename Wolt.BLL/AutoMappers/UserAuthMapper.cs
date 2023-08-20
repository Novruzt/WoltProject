using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.AutoMappers
{
    public class UserAuthMapper:Profile
    {
        public UserAuthMapper()
        {

            CreateMap<User, GetUserProfileDTO>();

            CreateMap<LoginUserRequestDTO, User>();
            CreateMap<RegisterUserRequestDTO, User>()
                .ForSourceMember(src => src.ProfilePic, opt => opt.DoNotValidate());
           
           

        }
    }
}
