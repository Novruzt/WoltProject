using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Configurations;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.UnitOfWork.Abstract;

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

        public Task DeleteComment(string token, int CommId)
        {
            throw new NotImplementedException();
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

        public Task<List<UserReview>> GetAllUserReviewsAsync(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserCommentDTO> GetCommentAsync(string token, int commId)
        {
            int userId = JwtService.GetIdFromToken(token);

            UserComment comment = await _UnitOfWork.UserInteractRepository.GetCommentAsync(userId, commId);
            GetUserCommentDTO result = _mapper.Map<GetUserCommentDTO>(comment);

            return result;

        }

        public Task<UserReview> GetUserReviewAsync(int id, int revId)
        {
            throw new NotImplementedException();
        }

        public Task ReturnOrderAsync(string token, int OrderId, string reason)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCommentAsync(string token, int commId, string desc)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserBasketAsync(string token, List<Product> products, int? PromodoCodeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserReviewAsync(string token, int RevId, int? score, string desc)
        {
            throw new NotImplementedException();
        }
    }
}
