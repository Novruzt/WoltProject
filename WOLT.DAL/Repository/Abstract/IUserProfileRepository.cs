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
        Task<UserAddress> GetUserAddressesAsync(int id, int addressId); 
        Task<List<UserHistory>> GetAllHistoryAsync(int id); 
        Task<List<UserPayment>> GetAllUserPaymentsAsync(int id); 
        Task AddUserPayment(UserPayment payment);    
        Task DeleteUserPaymentAsync(int id, int PaymentId); 
        Task<List<Order>> GetAllOrdersAsync(int id); 
        Task<Order> GetOrderAsync(int id, int OrderId); 
    }
}
