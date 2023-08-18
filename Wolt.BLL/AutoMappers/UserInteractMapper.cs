using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.DATA;

namespace Wolt.BLL.AutoMappers
{
    public class UserInteractMapper:Profile
    {
        public UserInteractMapper()
        {

            // dest=> dest.UserName, opt => opt.MapFrom(src=>src.User.Name)

            CreateMap<AddUserCommentDTO, UserComment>();
            CreateMap<AddUserReviewDTO, UserReview>();
            CreateMap<AddUserBasketDTO, Basket>()
                .ForSourceMember(src=>src.Quantity, opt=>opt.DoNotValidate())
                .ForSourceMember(src=>src.ProductId, opt=>opt.DoNotValidate());
           
                
                

           


            CreateMap<UserComment, GetUserCommentDTO>();
            CreateMap<UserComment, GetAllUserCommentsDTO>();

            CreateMap<UserReview, GetAllUserReviewsDTO>();
            CreateMap<UserReview, GetUserReviewDTO>();
               
            
        }


    }

    
}
