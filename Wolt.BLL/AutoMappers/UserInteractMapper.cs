using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.AutoMappers
{
    public class UserInteractMapper:Profile
    {
        public UserInteractMapper()
        {

            CreateMap<AddUserCommentDTO, UserComment>();

            CreateMap<UserComment, GetUserCommentDTO>();
            CreateMap<UserComment, GetAllUserCommentsDTO>()
                .ForMember(dest=>dest.UserName, opt=>opt.MapFrom(src=>src.User.Name))
                .ForMember(dest=>dest.RestaurantName, opt=>opt.MapFrom(src=>src.Restaurant.Name));
        }
    }
}
