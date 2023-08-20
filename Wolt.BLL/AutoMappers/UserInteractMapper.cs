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
            CreateMap<Basket, GetUserBasketDTO>();
            CreateMap<Product, GetProductsForBasketDTO>()
                .ForMember(dest=>dest.Quantity, opt=>opt.Ignore());

            CreateMap<AddUserBasketDTO, Basket>()
                .ForSourceMember(src=>src.Quantity, opt=>opt.DoNotValidate());
           
            CreateMap<UserComment, GetUserCommentDTO>()
                .ForMember(dest=>dest.CreationTime, opt=>opt.MapFrom(src=>src.CreationTime));

            CreateMap<UserComment, GetAllUserCommentsDTO>();

            CreateMap<UserReview, GetAllUserReviewsDTO>()
                .ForMember(dest=>dest.UserName, opt=>opt.MapFrom(src=>src.User.Name))
               .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.Name));

            CreateMap<UserReview, GetUserReviewDTO>()
                .ForMember(dest=>dest.UserName, opt=>opt.MapFrom(src=>src.User.Name))
                .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.Name))
                .ForMember(dest=>dest.CreationTime, opt=>opt.MapFrom(src=>src.CreationTime));
               
            
        }


    }

    
}
