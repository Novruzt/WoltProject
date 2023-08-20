using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Configurations;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.Enums;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.UnitOfWork.Abstract;
using WOLT.DAL.UnitOfWork.Concrete;

namespace Wolt.BLL.Services.Concrete
{
    public class UserInteractService : IUserInteractService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public UserInteractService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResultDTO> AddCommentAsync(string token,AddUserCommentDTO comment)
        {

            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            comment.UserId = JwtService.GetIdFromToken(token);

            if (comment.UserId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserCommentForRestaurantAsync(comment.UserId,comment.RestaurantId);

            if (IsComment)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "You already have commented for this restuanrant";

                return result;
            }

            try
            {
                UserComment data = _mapper.Map<UserComment>(comment);

                await _UnitOfWork.UserInteractRepository.AddCommentAsync(data);
                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "You added comment succesfully!";

                return result;

            }
            catch (Exception ex)
            {
                result.Status = RequestStatus.Failed;
                result.Message = ex.Message;

                return result;
            }

        }

        public async Task<BaseResultDTO> AddUserBasketAsync(string token, AddUserBasketDTO dto)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            dto.UserId = JwtService.GetIdFromToken(token);

            if (dto.UserId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }

            bool IsBasket = await _UnitOfWork.ThingsRepository.CheckUserBasketAsync(dto.UserId);

            if(IsBasket) 
            {
                result.Status= RequestStatus.Failed;
                result.Message = "You already have created basket";

                return result;
            }

            try
            {
                Basket basket = _mapper.Map<Basket>(dto);

                Product product = await _UnitOfWork.RestaurantRepository.GetProductAsync(dto.ProductId);

                if (product == null) 
                {

                    result.Status = RequestStatus.Failed;
                    result.Message = "No Food found!";

                    return result;
                
                }


                for (int i = 0; i<dto.Quantity; i++)
                {
                    basket.Products.Add(product);
                }

                basket.TotalAmount *= dto.Quantity * product.Price;

                await _UnitOfWork.UserInteractRepository.AddUserBasketAsync(basket);
                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = $"You created basket succesfully! You total amount is {basket.TotalAmount}";

                return result;
            }

            catch(Exception ex) 
            {
                result.Status = RequestStatus.Failed;
                result.Message=ex.Message;

                return result;
            }

            
        }

        public async Task<BaseResultDTO> AddUserReviewAsync(string token, AddUserReviewDTO dto)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            dto.UserId = JwtService.GetIdFromToken(token);

            if (dto.UserId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }

            bool IsReview = await _UnitOfWork.ThingsRepository.CheckUserReviewForProductAsync(dto.UserId, dto.ProductId);

            if (IsReview)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "You already have reviewed for this product";

                return result;
            }

            try
            {
               UserReview review = _mapper.Map<UserReview>(dto);

                await _UnitOfWork.UserInteractRepository.AddUserReviewAsync(review);
                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "You added review succesfully!";

                return result;

            }
            catch (Exception ex)
            {
                result.Status = RequestStatus.Failed;
                result.Message = ex.Message;

                return result;
            }
        }

        public async Task<BaseResultDTO> DeleteCommentAsync(string token, int CommId)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            int userId = JwtService.GetIdFromToken(token);

            if (userId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserCommentAsync(userId, CommId);

            if (!IsComment)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "No Comment Found!";

                return result;
            }

            try
            {

                await _UnitOfWork.UserInteractRepository.DeleteComment(userId, CommId);

                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "You deleted comment succesfully!";

                return result;

            }
            catch (Exception ex)
            {
                result.Status = RequestStatus.Failed;
                result.Message = ex.Message;

                return result;
            }

        }

        public async Task<BaseResultDTO> DeleteUserBasketAsync(string token)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

           int userId = JwtService.GetIdFromToken(token);

            if (userId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }

            bool IsBasket = await _UnitOfWork.ThingsRepository.CheckUserBasketAsync(userId);

            if (!IsBasket)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "No Basket Found";

                return result;
            }

            try
            {

                await _UnitOfWork.UserInteractRepository.DeleteUserBasket(userId);

                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "You deleted Basket succesfully!";

                return result;

            }

            catch (Exception ex) 
            {

                result.Status= RequestStatus.Failed;
                result.Message = ex.Message;

                return result;

            }


            
        }

        public async Task<List<GetAllUserCommentsDTO>> GetAllCommentsAsync(string token)
        {
            int userId = JwtService.GetIdFromToken(token);

            List<UserComment> datas = await _UnitOfWork.UserInteractRepository.GetAllCommentsAsync(userId);
            List<GetAllUserCommentsDTO> list = _mapper.Map<List<GetAllUserCommentsDTO>>(datas);

            return list;
        }

        public async Task<List<GetAllUserReviewsDTO>> GetAllReviewsAsync(string token)
        {
            int userId = JwtService.GetIdFromToken(token);

            List<UserReview> datas = await _UnitOfWork.UserInteractRepository.GetAllUserReviewsAsync(userId);
            List<GetAllUserReviewsDTO> list = _mapper.Map<List<GetAllUserReviewsDTO>>(datas);

            return list;
        }

        public async Task<GetUserCommentDTO> GetCommentAsync(string token, int commId)
        {
            int userId = JwtService.GetIdFromToken(token);

            UserComment comment = await _UnitOfWork.UserInteractRepository.GetCommentAsync(userId, commId);
            GetUserCommentDTO result = _mapper.Map<GetUserCommentDTO>(comment);

            return result;

        }

        public async Task<GetUserReviewDTO> GetUserReviewAsync(string token, int revId)
        {
            int userId = JwtService.GetIdFromToken(token);

            UserReview review = await _UnitOfWork.UserInteractRepository.GetUserReviewAsync(userId, revId);
            GetUserReviewDTO result = _mapper.Map<GetUserReviewDTO>(review);

            return result;
        }

        public async Task<BaseResultDTO> ReturnOrderAsync(string token, ReturnOrderDTO dto)
        {

            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            int userId = JwtService.GetIdFromToken(token);

            if (userId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }

            bool IsOrder = await _UnitOfWork.ThingsRepository.CheckUserOrderAsync(userId, dto.OrderId);

            if (!IsOrder)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "No Order Found!";

                return result;
            }

            try
            {
                await _UnitOfWork.UserInteractRepository.ReturnOrderAsync(userId, dto.OrderId, dto.Reason);

                _UnitOfWork.Commit();

                result.Message = "Order retur succes!";
                result.Status = RequestStatus.Success;

                return result;
            }

            catch (Exception ex) 
            {

                result.Status = RequestStatus.Failed;
                result.Message = ex.Message;

                return result;
            }



            return result;
        }

        public async Task<BaseResultDTO> UpdateCommentAsync(string token, UpdateCommentDTO dto)
        {
            BaseResultDTO result = new BaseResultDTO();

              bool IsToken =  JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status=RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }
               
            int userId = JwtService.GetIdFromToken(token);

            if (userId <= 0)
            {
                result.Status=RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }      

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserCommentAsync(userId, dto.commId);
 
            if (!IsComment)
            {
                result.Status=RequestStatus.Failed;
                result.Message = "No Comment Found!";

                return result;
            }
                
            try
            {

                await _UnitOfWork.UserInteractRepository.UpdateCommentAsync(userId, dto.commId, dto.desc);
                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "You changed comment succesfully!";

                return result;

            }
            catch(Exception ex)
            { 
                result.Status=RequestStatus.Failed;
                result.Message=ex.Message;

                return result;
            }

           
        }

        public Task<BaseResultDTO> UpdateUserBasketAsync(string token, List<Product> products, int? PromodoCodeId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResultDTO> UpdateUserReviewAsync(string token, UpdateReviewDTO dto)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            int userId = JwtService.GetIdFromToken(token);

            if (userId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserReviewAsync(userId, dto.revId);

            if (!IsComment)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "No Review Found!";

                return result;
            }

            try
            {

                await _UnitOfWork.UserInteractRepository.UpdateUserReviewAsync(userId, dto.revId, dto.Score, dto.Description);
                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "You changed review succesfully!";

                return result;

            }
            catch (Exception ex)
            {
                result.Status = RequestStatus.Failed;
                result.Message = ex.Message;

                return result;
            }
        }


    }
}
