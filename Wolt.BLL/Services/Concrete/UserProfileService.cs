using AutoMapper;
using DocumentFormat.OpenXml.Math;
using FluentValidation;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.DTOs.UserProfileDTOs;
using Wolt.BLL.Enums;
using Wolt.BLL.Exceptions;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.Repository.Abstract;
using WOLT.DAL.UnitOfWork.Abstract;
using WOLT.DAL.UnitOfWork.Concrete;

namespace Wolt.BLL.Services.Concrete
{
    public class UserProfileService : IUserProfileService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AddUserPaymentDTO> _cardvalidator;

        public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<AddUserPaymentDTO> cardValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cardvalidator = cardValidator;
        }
        public async Task AddUserPayment(string token, AddUserPaymentDTO dto)
        {
            dto.UserId = JwtService.GetIdFromToken(token);

            var Validator = _cardvalidator.Validate(dto);
            if (!Validator.IsValid)
                throw new BadRequestException(Validator.GetErrorMessages());

            bool IsCard = await _unitOfWork.ThingsRepository.CheckUserPaymentAsync(dto.UserId, dto.CardNumber, dto.CVV, dto.ExpireTime);

            if (IsCard)
                throw new BadRequestException("You already have added this card.");
            try
            {
                UserCard card= _mapper.Map<UserCard>(dto);
                
                await _unitOfWork.UserProfileRepository.AddUserPayment(card);
                await _unitOfWork.CommitAsync();

            }
            catch(Exception ex) 
            {
                throw new BadRequestException(ex);
            }

           
        }

        public async Task DeleteUserPaymentAsync(string token, DeleteUserCardDTO dto)
        {
            int userId = JwtService.GetIdFromToken(token);

            bool IsCard = await _unitOfWork.ThingsRepository.CheckUserCardBySensetiveInfoAsync(userId, dto.CardID, dto.CVV, dto.ExpireDate);

            if (!IsCard)
                throw new NotFoundException("Enter valid card details");

            try
            {

                await _unitOfWork.UserProfileRepository.DeleteUserPaymentAsync(userId, dto.CardID);
                await _unitOfWork.CommitAsync();

            }

            catch(Exception ex) 
            {
                throw new BadRequestException(ex);
            }

      
        }

        public async Task<List<GetAllUserFavoriteFoodsDTO>> GetAllFavoriteFoodAsync(string token)
        {
            int userId = JwtService.GetIdFromToken(token);

            List<FavoriteFood> datas = await _unitOfWork.UserProfileRepository.GetAllFavoriteFoodAsync(userId);
            List<GetAllUserFavoriteFoodsDTO> list = _mapper.Map<List<GetAllUserFavoriteFoodsDTO>>(datas);

            return list;
        }

        public async Task<List<GetAllFavoriteRestaurantsDTO>> GetAllFavoriteRestaurantsAsync(string token)
        {
            int UserId = JwtService.GetIdFromToken(token);

            List<FavoriteRestaurant> datas = await _unitOfWork.UserProfileRepository.GetAllFavoriteRestaurantsAsync(UserId);
            List<GetAllFavoriteRestaurantsDTO> list =  _mapper.Map<List<GetAllFavoriteRestaurantsDTO>>(datas);

            return list;

        }

        public async Task<List<GetAllUserHistoryDTO>> GetAllHistoryAsync(string token)
        {

            int UserId= JwtService.GetIdFromToken(token);

            List<Order> datas = await _unitOfWork.UserProfileRepository.GetAllHistoryAsync(UserId);
            List<GetAllUserHistoryDTO> list = _mapper.Map<List<GetAllUserHistoryDTO>>(datas);

            return list;
        }

        public async Task<List<GetAllUserHistoryDTO>> GetAllActiveOrdersAsync(string token)
        {
            int UserId = JwtService.GetIdFromToken(token);

            List<Order> datas = await _unitOfWork.UserProfileRepository.GetAllOrdersAsync(UserId);
            List<GetAllUserHistoryDTO> list = _mapper.Map<List<GetAllUserHistoryDTO>>(datas);

            return list;
        }

        public async Task<List<GetAllUserAdressDTO>> GetAllUserAddressesAsync(string token)
        {
            int userId = JwtService.GetIdFromToken(token);

            List<UserAddress> datas= await _unitOfWork.UserProfileRepository.GetAllUserAddressesAsync(userId);
            List<GetAllUserAdressDTO> list =  _mapper.Map<List<GetAllUserAdressDTO>>(datas);

            return list;


        }

        public async Task<List<GetAllUserCardDTO>> GetAllUserPaymentsAsync(string token)
        {
            
            int userID = JwtService.GetIdFromToken(token);

            List<UserCard> userCards = await _unitOfWork.UserProfileRepository.GetAllUserPaymentsAsync(userID);

            List<GetAllUserCardDTO> list = _mapper.Map<List<GetAllUserCardDTO>>(userCards); 

            foreach(GetAllUserCardDTO item in list)
            {
                item.CardNumber = BankCardService.MaskCardNumber(item.CardNumber);
                item.CVV = BankCardService.MaskSensitiveInfo("***", item.CVV.Length);
                item.ExpireTime = BankCardService.MaskSensitiveInfo("***", item.ExpireTime.Length);
            }


            return list;
        }   

        public async Task<UserFavoriteFoodDTO> GetFavoriteFoodAsync(string token, int favId)
        {
            int userId = JwtService.GetIdFromToken(token);

            FavoriteFood data = await _unitOfWork.UserProfileRepository.GetFavoriteFoodAsync(userId, favId);
            UserFavoriteFoodDTO dto= _mapper.Map<UserFavoriteFoodDTO>(data);

            return dto;


        }

        public async Task<UserFavoriteRestaurantDTO> GetFavoriteRestaurantsAsync(string token, int favId)
        {
            int UserID = JwtService.GetIdFromToken(token);

            FavoriteRestaurant data= await _unitOfWork.UserProfileRepository.GetFavoriteRestaurantsAsync(UserID, favId);
            UserFavoriteRestaurantDTO dto = _mapper.Map<UserFavoriteRestaurantDTO>(data);

            return dto;

        }

        public async Task<GetOrderDTO> GetOrderAsync(string token, int OrderId)
        {
            int UserId = JwtService.GetIdFromToken(token);

            Order order = await _unitOfWork.UserProfileRepository.GetOrderAsync(UserId, OrderId);
            GetOrderDTO dto = _mapper.Map<GetOrderDTO>(order);

            if (dto != null)
            {
                var productQuantities = new List<GetOrderProductsDTO>();

                foreach (var group in order.Products.GroupBy(p => p.Id))
                {
                    int productId = group.Key;

                    OrderProductQuantity productQuantity = await _unitOfWork.UserInteractRepository.GetOrderQuantityAsync(order.Id, productId);

                    productQuantities.Add(new GetOrderProductsDTO
                    {
                        ProductId = productId,
                        Quantity = productQuantity.Quantity,
                        Name = group.First().Name,
                        Description = group.First().Description,
                        Price = group.First().Price,
                        Picture = group.First().Picture,

                    });
                }

                dto.Products = productQuantities;
            }

            return dto;
        }

    }
}
