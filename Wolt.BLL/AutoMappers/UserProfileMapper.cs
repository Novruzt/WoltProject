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
            CreateMap<FavoriteFood, UserFavoriteFoodDTO>();
        }
    }
}
