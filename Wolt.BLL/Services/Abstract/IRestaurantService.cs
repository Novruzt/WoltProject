using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.Others;
using Wolt.BLL.DTOs.RestaurantDTOs;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.Services.Abstract
{
    public interface IRestaurantService
    {
        Task<List<GetAllRestaurantsDTO>> GetAllAsync();
        Task<GetRestaurantDTO> GetAsync(int id);
        Task<List<GetAllCategoriesDTO>> GetAllCategoriesAsync(int id);
        Task<List<GetAllProductsDTO>> GetAllProductsAsync(int id);
        Task<GetProductDTO> GetProductAsync(int id);
        Task<List<GetAllUserCommentsForRestaurantDTO>> GetAllCommentsAsync(int id);
        Task<List<GetAllReviewsForProductDTO>> GetUserReviewsAsync(int id);
      
    }
}
