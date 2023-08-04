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
           /*
             
             CreateMap<City, ListCityDTO>()
               .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Name));

            */

            CreateMap<Restaurant, GetAllRestaurantsDTO>();
            CreateMap<Restaurant, GetRestaurantDTO>();


            CreateMap<Discount, GetAllDiscountsDTO>();
            CreateMap<WorkHours, WorkHoursDTO>();
            CreateMap<UserComment, GetUserCommentsForRestaurantDTO>()
                .ForMember(dest=> dest.UserName, opt => opt.MapFrom(src=>src.User.Name));

        }
    }
}
