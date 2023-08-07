using AutoMapper;
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
        public async Task AddCommentAsync(AddUserCommentDTO comment)
        {
            

           UserComment data =_mapper.Map<UserComment>(comment);
          
           await  _UnitOfWork.UserInteractRepository.AddCommentAsync(data);
           _UnitOfWork.Commit();

        }

        public Task AddUserBasketAsync(Basket basket)
        {
            throw new NotImplementedException();
        }

        public Task AddUserReviewAsync(UserReview userReview)
        {
            throw new NotImplementedException();
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

        public Task DeleteUserBasket(string token)
        {
            throw new NotImplementedException();
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

        public Task UpdateUserBasketAsync(string token, List<Product> products, int? PromodoCodeId)
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
