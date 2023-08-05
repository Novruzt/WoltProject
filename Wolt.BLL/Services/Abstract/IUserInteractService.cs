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
        Task<List<GetAllUserCommentsDTO>> GetAllCommentsAsync(int id);
        Task<GetUserCommentDTO> GetCommentAsync(int id, int commId);
        Task UpdateCommentAsync(int id, int commId, string desc);
        Task DeleteComment(int id, int CommId);
        Task ReturnOrderAsync(int id, int OrderId, string reason);
        Task<List<UserReview>> GetAllUserReviewsAsync(int id);
        Task<UserReview> GetUserReviewAsync(int id, int revId);
        Task UpdateUserReviewAsync(int id, int RevId, int? score, string desc);
        Task AddUserReviewAsync(UserReview userReview);
        Task AddUserBasketAsync(Basket basket);
        Task DeleteUserBasket(int id);
        Task UpdateUserBasketAsync(int id, List<Product> products, int? PromodoCodeId);
    }
}
