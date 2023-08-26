using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace WOLT.DAL.Repository.Abstract
{
    public interface IUserProfileRepository
    {
        Task<List<FavoriteFood>> GetAllFavoriteFoodAsync(int id); 
        Task<FavoriteFood> GetFavoriteFoodAsync(int id, int favId); 
        Task<List<FavoriteRestaurant>> GetAllFavoriteRestaurantsAsync(int id); 
        Task<FavoriteRestaurant> GetFavoriteRestaurantsAsync(int id, int favId);
        Task<List<UserAddress>> GetAllUserAddressesAsync(int id); 
        Task<List<Order>> GetAllHistoryAsync(int id); 
        Task<UserHistory> GetUserHistory(int id);
        Task<List<UserCard>> GetAllUserPaymentsAsync(int id); 
        Task AddUserPayment(UserCard payment);    
        Task DeleteUserPaymentAsync(int id, int PaymentId); 
        Task<List<Order>> GetAllOrdersAsync(int id); 
        Task<Order> GetOrderAsync(int id, int OrderId);
        Task AddFavoriteFoodAsync(FavoriteFood food);
        Task AddFavoriteRestaurantAsync(FavoriteRestaurant restaurant);
        Task<UserAddress> GetUserAddressAsync(int id, int? adressId);
        Task AddUserAdressAsync(UserAddress address);
        Task RemoveNewAdressAsync(int id, int adressId);
        
    }
}
