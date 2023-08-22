using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.RestaurantDTOs;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.AutoMappers
{
    public class RestaurantMapper:Profile
    {
        public RestaurantMapper()
        {

            CreateMap<Restaurant, GetAllRestaurantsDTO>();
            CreateMap<Restaurant, GetRestaurantDTO>();

           
            CreateMap<UserComment, GetAllUserCommentsForRestaurantDTO>()
                .ForMember(dest=> dest.UserName, opt => opt.MapFrom(src=>src.User.Name))
                .ForMember(dest=>dest.CommentDate, opt=>opt.MapFrom(src=>src.CreationTime));

            CreateMap<Category, GetAllCategoriesDTO>();
            CreateMap<Product, GetAllProductsDTO>();
            CreateMap<Product, GetProductDTO>();
            CreateMap<UserReview, GetAllReviewsForProductDTO>()
                .ForMember(dest=>dest.UserName, opt=>opt.MapFrom(src=>src.User.Name))
                .ForMember(dest=>dest.ReviewDate, opt=>opt.MapFrom(src=>src.CreationTime));

               
                

        }
    }
}
