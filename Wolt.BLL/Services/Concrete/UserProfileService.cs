using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.DTOs.UserProfileDTOs;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.UnitOfWork.Abstract;
using WOLT.DAL.UnitOfWork.Concrete;

namespace Wolt.BLL.Services.Concrete
{
    public class UserProfileService : IUserProfileService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public Task AddUserPayment(UserPayment payment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserPaymentAsync(string token, int PaymentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllUserFavoriteFoodsDTO>> GetAllFavoriteFoodAsync(string token)
        {
            int userId = JwtService.GetIdFromToken(token);

            List<FavoriteFood> datas = await _unitOfWork.UserProfileRepository.GetAllFavoriteFoodAsync(userId);
            List<GetAllUserFavoriteFoodsDTO> list = _mapper.Map<List<GetAllUserFavoriteFoodsDTO>>(datas);

            return list;
        }

        public Task<List<FavoriteRestaurant>> GetAllFavoriteRestaurantsAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserHistory>> GetAllHistoryAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserAddress>> GetAllUserAddressesAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserPayment>> GetAllUserPaymentsAsync(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<UserFavoriteFoodDTO> GetFavoriteFoodAsync(string token, int favId)
        {
            int userId = JwtService.GetIdFromToken(token);

            FavoriteFood data = await _unitOfWork.UserProfileRepository.GetFavoriteFoodAsync(userId, favId);
            UserFavoriteFoodDTO dto= _mapper.Map<UserFavoriteFoodDTO>(data);

            return dto;


        }

        public Task<FavoriteRestaurant> GetFavoriteRestaurantsAsync(string token, int favId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderAsync(string token, int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<UserAddress> GetUserAddressesAsync(string token, int addressId)
        {
            throw new NotImplementedException();
        }
    }
}
