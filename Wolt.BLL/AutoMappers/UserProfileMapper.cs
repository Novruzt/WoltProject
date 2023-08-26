using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserProfileDTOs;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace Wolt.BLL.AutoMappers
{
    public class UserProfileMapper :Profile
    {
        public UserProfileMapper()
        {

            CreateMap<FavoriteFood, GetAllUserFavoriteFoodsDTO>();
            CreateMap<FavoriteRestaurant, GetAllFavoriteRestaurantsDTO>();
            CreateMap<UserAddress, GetAllUserAdressDTO>();
            CreateMap<UserCard, GetAllUserCardDTO>();
            CreateMap<AddUserPaymentDTO, UserCard>();

            CreateMap<Order, GetOrderDTO>()
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus.ToString()))
                .ForMember(dest => dest.UserLocation, opt => opt.MapFrom(src => src.UserAddress.City + ": " + src.UserAddress.Location));

            CreateMap<Product, GetOrderProductsDTO>()
                .ForMember(dest => dest.Quantity, opt => opt.Ignore())
                .ForMember(dest=>dest.Name, opt=>opt.MapFrom(src=>src.Name))
                .ForMember(dest=>dest.Price, opt=>opt.MapFrom(src=>src.Price));

            CreateMap<Order, GetAllUserHistoryDTO>()
                .ForMember(dest=>dest.OrderAddress, opt=>opt.MapFrom((src=>src.UserAddress.City+ ": "+ src.UserAddress.Location)))
                .ForMember(dest=>dest.OrderStatus, opt=>opt.MapFrom(src=>src.OrderStatus.ToString()))
                .ForMember(dest=>dest.OrderTime, opt=>opt.MapFrom(src=>src.CreationTime))
                .ForMember(dest=>dest.OrderTotalAmount, opt=>opt.MapFrom(src=>src.TotalPrice))
                .ForMember(dest=>dest.Description, opt=>opt.MapFrom(src=>src.Description));

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

            CreateMap<AddUserAdressDTO, UserAddress>();

        }
    }
}
