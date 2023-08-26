using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace WOLT.DAL.Repository.Abstract
{
    public interface IUserInteractRepository
    {
      
        Task AddCommentAsync(UserComment comment); 
        Task<List<UserComment>> GetAllCommentsAsync(int id); 
        Task<UserComment> GetCommentAsync(int id, int commId); 
        Task UpdateCommentAsync(int id, int commId, string desc); 
        Task DeleteCommentAsync(int id, int CommId);
        Task DeleteReviewAsync(int id, int RevId);
        Task  ReturnOrderAsync(int id, int OrderId, string reason);  
        Task<List<UserReview>> GetAllUserReviewsAsync(int id); 
        Task<UserReview> GetUserReviewAsync(int id, int revId); 
        Task UpdateUserReviewAsync(int id, int RevId, double? score, string? desc);
        Task AddUserReviewAsync(UserReview userReview); 
        Task AddUserBasketAsync(Basket basket); 
        Task DeleteUserBasketAsync(int id); 
        Task UpdateUserBasketAsync(int id, List<Product> products, int? PromodoCodeId);
        Task<UserComment> GetDeletedCommentFromRestaurantAsync(int id, int RestId);
        Task<UserReview> GetDeletedReviewFromProductAsync(int id, int ProductId);
        Task<Basket> GetUserBasketAsync(int id);
        Task AddBasketQuantityAsync(int BasketId, int ProductId, int Quantity);
        Task<BasketProductQuantity> GetBasketQuantityAsync(int basketId, int ProductId);
        Task OrderBasketAsync(Order order);
        Task AddOrderQuantityAsync(int orderId, int ProductId,  int quantity);
        Task<OrderProductQuantity> GetOrderQuantityAsync(int orderId, int ProductId);
        Task<PromoCode> GetPromoCodeAsync(int? id);
        Task AddOrderHistoryAsync(int id, int orderId);
        Task CreateUserHistoryAsync(int id);
        Task AddFavoriteFoodAsync(FavoriteFood food);
        Task AddFavoriteRestaurantAsync(FavoriteRestaurant favorite);
        Task DeleteFavFoodAsync(int id, int  favId);
        Task DeleteFavRestaurantAsync(int id, int favId);
    }
}
