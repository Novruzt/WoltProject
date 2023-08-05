using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.Services.Abstract;
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
           await _UnitOfWork.CommitAsync();

        }

        public Task AddUserBasketAsync(Basket basket)
        {
            throw new NotImplementedException();
        }

        public Task AddUserReviewAsync(UserReview userReview)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(int id, int CommId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserBasket(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllUserCommentsDTO>> GetAllCommentsAsync(int id)
        {
            List<UserComment> datas = await _UnitOfWork.UserInteractRepository.GetAllCommentsAsync(id);
            List<GetAllUserCommentsDTO> list = _mapper.Map<List<GetAllUserCommentsDTO>>(datas);

            return list;
        }

        public Task<List<UserReview>> GetAllUserReviewsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserCommentDTO> GetCommentAsync(int id, int commId)
        {

            UserComment comment = await _UnitOfWork.UserInteractRepository.GetCommentAsync(id, commId);
            GetUserCommentDTO result = _mapper.Map<GetUserCommentDTO>(comment);

            return result;

        }

        public Task<UserReview> GetUserReviewAsync(int id, int revId)
        {
            throw new NotImplementedException();
        }

        public Task ReturnOrderAsync(int id, int OrderId, string reason)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCommentAsync(int id, int commId, string desc)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserBasketAsync(int id, List<Product> products, int? PromodoCodeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserReviewAsync(int id, int RevId, int? score, string desc)
        {
            throw new NotImplementedException();
        }
    }
}
