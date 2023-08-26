using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserProfileDTOs;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace Wolt.BLL.Services.Abstract
{
    public interface IUserProfileService
    {
        Task<List<GetAllUserFavoriteFoodsDTO>> GetAllFavoriteFoodAsync(string token);
        Task<UserFavoriteFoodDTO> GetFavoriteFoodAsync(string token, int favId);
        Task<List<GetAllFavoriteRestaurantsDTO>> GetAllFavoriteRestaurantsAsync(string token);
        Task<UserFavoriteRestaurantDTO> GetFavoriteRestaurantsAsync(string token, int favId);
        Task<List<GetAllUserAdressDTO>> GetAllUserAddressesAsync(string token);
        Task<List<GetAllUserHistoryDTO>> GetAllHistoryAsync(string token); 
        Task<List<GetAllUserCardDTO>> GetAllUserPaymentsAsync(string token);
        Task AddUserPayment(string token, AddUserPaymentDTO dto);
        Task DeleteUserPaymentAsync(string token, DeleteUserCardDTO dto);
        Task<List<GetAllUserHistoryDTO>> GetAllActiveOrdersAsync(string token);
        Task<GetOrderDTO> GetOrderAsync(string token, int OrderId);
        Task AddUserAdressAsync(string token, AddUserAdressDTO dto);
        Task DeleteUserAdressAsync(string token, int adressId);
    }
}
