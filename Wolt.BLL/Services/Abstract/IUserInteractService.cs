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
        Task<BaseResultDTO> AddCommentAsync(string token, AddUserCommentDTO comment);
        Task<List<GetAllUserCommentsDTO>> GetAllCommentsAsync(string token);
        Task<GetUserCommentDTO> GetCommentAsync(string token, int commId);
        Task<BaseResultDTO> UpdateCommentAsync(string token, UpdateCommentDTO dto);
        Task<BaseResultDTO> DeleteCommentAsync(string token, int CommId);
        Task<BaseResultDTO> ReturnOrderAsync(string token, ReturnOrderDTO dto);
        Task<List<GetAllUserReviewsDTO>> GetAllReviewsAsync(string token);
        Task<GetUserReviewDTO> GetUserReviewAsync(string token, int revId);
        Task<BaseResultDTO> UpdateUserReviewAsync(string token, UpdateReviewDTO dto);
        Task<BaseResultDTO> AddUserReviewAsync(string token, AddUserReviewDTO dto);
        Task<BaseResultDTO> AddUserBasketAsync(string token, AddUserBasketDTO dto); //bunu yazram indi // xetalar var. 
        Task<BaseResultDTO> DeleteUserBasketAsync(string token); 
        Task<BaseResultDTO> UpdateUserBasketAsync(string token, List<Product> products, int? PromodoCodeId); //AddUserbAsketAsync ile eyni problem yasanacag.
    }
}
