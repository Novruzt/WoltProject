using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace Wolt.BLL.Services.Abstract
{
    public interface IUserInteractService
    {
        Task AddCommentAsync(AddUserCommentDTO comment);
        Task<List<GetAllUserCommentsDTO>> GetAllCommentsAsync(string token);
        Task<GetUserCommentDTO> GetCommentAsync(string token, int commId);
        Task UpdateCommentAsync(string token, int commId, string desc);
        Task DeleteComment(string token, int CommId);
        Task ReturnOrderAsync(string token, int OrderId, string reason);
        Task<List<UserReview>> GetAllUserReviewsAsync(string token);
        Task<UserReview> GetUserReviewAsync(int id, int revId);
        Task UpdateUserReviewAsync(string token, int RevId, int? score, string desc);
        Task AddUserReviewAsync(UserReview userReview);
        Task AddUserBasketAsync(Basket basket);
        Task DeleteUserBasket(string token);
        Task UpdateUserBasketAsync(string token, List<Product> products, int? PromodoCodeId);
    }
}
