using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserProfileDTOs;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.AutoMappers
{
    public class UserProfileMapper :Profile
    {
        public UserProfileMapper()
        {

            CreateMap<FavoriteFood, GetAllUserFavoriteFoodsDTO>();
            CreateMap<FavoriteRestaurant, GetAllFavoriteRestaurantsDTO>();
            CreateMap<FavoriteRestaurant, UserFavoriteRestaurantDTO>()
                .ForMember(dest=>dest.Categories, opt=>opt.MapFrom(dest=>dest.Restaurant.Categories.Count))
                .ForMember(dest=>dest.Name, opt=>opt.MapFrom(dest=>dest.Restaurant.Name))
                .ForMember(dest => dest.BaseAddress, opt=>opt.MapFrom(dest=>dest.Restaurant.BaseAddress))
                .ForMember(dest=>dest.Phone, opt=>opt.MapFrom(dest=>dest.Restaurant.Phone))
                .ForMember(dest=>dest.Description, opt=>opt.MapFrom(dest=>dest.Restaurant.Description));

            CreateMap<FavoriteFood, UserFavoriteFoodDTO>()
                .ForMember(dest=>dest.Name, opt=>opt.MapFrom(src=>src.Product.Name))
                .ForMember(dest=>dest.RestaurantName, opt=>opt.MapFrom(src=>src.Product.Category.Restaurant.Name))
                .ForMember(dest=>dest.Description, opt=>opt.MapFrom(src=>src.Product.Description))
                .ForMember(dest=>dest.Picture, opt=>opt.MapFrom(src=>src.Product.Picture))
                .ForMember(dest=>dest.CategoryName, opt=>opt.MapFrom(src=>src.Product.Category.Name))
                .ForMember(dest=>dest.Price, opt=>opt.MapFrom(src=>src.Product.Price));


        }
    }
}
