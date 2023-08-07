using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.ThingsDTO;
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
        Task<BaseResultDTO> UpdateCommentAsync(string token, UpdateCommentDTO dto);
        Task<BaseResultDTO> DeleteCommentAsync(string token, int CommId);
        Task<BaseResultDTO> ReturnOrderAsync(string token, ReturnOrderDTO dto);
        Task<List<GetAllUserReviewsDTO>> GetAllReviewsAsync(string token);
        Task<GetUserReviewDTO> GetUserReviewAsync(string token, int revId);
        Task<BaseResultDTO> UpdateUserReviewAsync(string token, UpdateReviewDTO dto);
        Task AddUserReviewAsync(UserReview userReview);
        Task AddUserBasketAsync(Basket basket);
        Task DeleteUserBasket(string token);
        Task UpdateUserBasketAsync(string token, List<Product> products, int? PromodoCodeId);
    }
}
