using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        Task AddCommentAsync(string token, AddUserCommentDTO comment);
        Task<List<GetAllUserCommentsDTO>> GetAllCommentsAsync(string token);
        Task<GetUserCommentDTO> GetCommentAsync(string token, int commId);
        Task UpdateCommentAsync(string token, UpdateCommentDTO dto);
        Task DeleteCommentAsync(string token, int CommId);
        Task ReturnOrderAsync(string token, ReturnOrderDTO dto);
        Task<List<GetAllUserReviewsDTO>> GetAllReviewsAsync(string token);
        Task<GetUserReviewDTO> GetUserReviewAsync(string token, int revId);
        Task UpdateUserReviewAsync(string token, UpdateReviewDTO dto);
        Task DeleteUserReviewAsync(string token, int revId);
        Task AddUserReviewAsync(string token, AddUserReviewDTO dto);
        Task AddUserBasketAsync(string token, AddUserBasketDTO dto);  
        Task DeleteUserBasketAsync(string token); 
        Task UpdateUserBasketAsync(string token, AddUserBasketDTO dto); 
        Task<GetUserBasketDTO> GetUserBasketAsync(string token);
        Task OrderBasketAsync(string token, OrderBasketDTO dto);
        Task AddFavoriteFoodAsync(string token, int FavId);
        Task AddFavoriteRestaurantAsync(string token, int favId);
        Task RemoveFavoriteFoodAsync(string token, int favId);
        Task RemoveFavoriteRestaurantAsync(string token, int FavId);


    }
}
