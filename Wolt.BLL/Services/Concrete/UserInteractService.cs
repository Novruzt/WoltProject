using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
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
using Wolt.Entities.Enums;
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
               

                bool IsDeleted = await _UnitOfWork.ThingsRepository.CheckDeletedCommentForRestaurantAsync(comment.UserId, comment.RestaurantId);

                if (IsDeleted)
                {
                    UserComment userComment = await _UnitOfWork.UserInteractRepository.GetDeletedCommentFromRestaurantAsync(comment.UserId, comment.RestaurantId);

                    userComment.Details = comment.Details;
                    userComment.IsDeleted = false;
                   

                    _UnitOfWork.Commit();

                    result.Status = RequestStatus.Success;
                    result.Message = "You added comment succesfully!";

                    return result;
                }


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

        public async Task<BaseResultDTO> AddFavoriteFoodAsync(string token, int FavId)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            int UserId = JwtService.GetIdFromToken(token);

            if (UserId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }

            bool IsFood = await _UnitOfWork.ThingsRepository.CheckProductAsync(FavId);

            if(!IsFood)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "This product doesnt exist!";

                return result;
            }

            bool Exist = await _UnitOfWork.ThingsRepository.CheckFavoriteFoodAsync(UserId, FavId);

            if(Exist) 
            {
                result.Status = RequestStatus.Failed;
                result.Message = "This food is already in your favorites";

                return result;
            }

            try
            {
                FavoriteFood food = new FavoriteFood()
                {
                    UserId=UserId,
                    ProductId=FavId
                };

                await _UnitOfWork.UserInteractRepository.AddFavoriteFoodAsync(food);
                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "Food added your favorites succesfully!";

                return result;

            }

            catch (Exception ex) 
            {
                result.Status= RequestStatus.Failed;
                result.Message=ex.Message;

                return result;
            }
        }

        public async Task<BaseResultDTO> AddFavoriteRestaurantAsync(string token, int FavId)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            int UserId = JwtService.GetIdFromToken(token);

            if (UserId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";
                return result;
            }

            bool IsRest = await _UnitOfWork.ThingsRepository.CheckRestaurantAsync(FavId);

            if (!IsRest)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "This restaurant doesnt exist!";
                return result;
            }

            bool Exist = await _UnitOfWork.ThingsRepository.CheckFavoriteRestaurantAsync(UserId, FavId);

            if (Exist)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "This restaurant is already in your favorites";

                return result;
            }

            try
            {
                FavoriteRestaurant fav = new FavoriteRestaurant()
                {
                    UserId = UserId,
                    RestaurantId= FavId
                };

                await _UnitOfWork.UserInteractRepository.AddFavoriteRestaurantAsync(fav);
                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "Restaurant added your favorites succesfully!";

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
                Basket basket = new Basket()
                {
                    UserId=dto.UserId
                };

                Product product = await _UnitOfWork.RestaurantRepository.GetProductAsync(dto.ProductId);

                if (product == null) 
                {

                    result.Status = RequestStatus.Failed;
                    result.Message = "No Food found!";

                    return result;
                
                }

                if (dto.Quantity <= 0)
                {
                    result.Status=RequestStatus.Failed;
                    result.Message = "Enter valid quantity. Quantity must be greater than 0";

                    return result;
                }
                
                for (int i = 0; i<dto.Quantity; i++)
                {
                    basket.Products.Add(product);
                }

                basket.TotalAmount = dto.Quantity * product.Price;

                await _UnitOfWork.UserInteractRepository.AddUserBasketAsync(basket);
                
                _UnitOfWork.Commit();

                await _UnitOfWork.UserInteractRepository.AddBasketQuantityAsync(basket.Id, dto.ProductId, dto.Quantity);

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

                bool IsDeleted = await _UnitOfWork.ThingsRepository.CheckDeletedReviewForProductAsync(dto.UserId, dto.ProductId);

                if (IsDeleted) 
                {

                    UserReview userReview = await _UnitOfWork.UserInteractRepository.GetDeletedReviewFromProductAsync(dto.UserId, dto.ProductId);

                    userReview.IsDeleted = false;
                    userReview.Score = dto.Score;
                    userReview.Description = dto.Description;

                    _UnitOfWork.Commit();

                    result.Status= RequestStatus.Success;
                    result.Message = "You added review succesfully!";

                    return result;

                }


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

                await _UnitOfWork.UserInteractRepository.DeleteCommentAsync(userId, CommId);

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

                await _UnitOfWork.UserInteractRepository.DeleteUserBasketAsync(userId);

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

        public async Task<BaseResultDTO> DeleteUserReviewAsync(string token, int revId)
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

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserReviewAsync(userId, revId);

            if (!IsComment)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "No Review Found!";

                return result;
            }

            try
            {

                await _UnitOfWork.UserInteractRepository.DeleteReviewAsync(userId, revId);

                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "You deleted review succesfully!";

                return result;

            }
            catch (Exception ex)
            {
                result.Status = RequestStatus.Failed;
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

        public async Task<GetUserBasketDTO> GetUserBasketAsync(string token)
        {
            int UserId = JwtService.GetIdFromToken(token);

            Basket basket = await _UnitOfWork.UserInteractRepository.GetUserBasketAsync(UserId);
            GetUserBasketDTO dto = _mapper.Map<GetUserBasketDTO>(basket);

            if (dto != null)
            {
                var productQuantities = new List<GetProductsForBasketDTO>();

                foreach (var group in basket.Products.GroupBy(p => p.Id))
                {
                    int productId = group.Key;

                    BasketProductQuantity productQuantity = await _UnitOfWork.UserInteractRepository.GetBasketQuantityAsync(basket.Id, productId);

                    productQuantities.Add(new GetProductsForBasketDTO
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

        public async Task<GetUserReviewDTO> GetUserReviewAsync(string token, int revId)
        {
            int userId = JwtService.GetIdFromToken(token);

            UserReview review = await _UnitOfWork.UserInteractRepository.GetUserReviewAsync(userId, revId);
            GetUserReviewDTO result = _mapper.Map<GetUserReviewDTO>(review);

            return result;
        }

        public  async Task<BaseResultDTO> OrderBasketAsync(string token, OrderBasketDTO dto)    
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
                result.Status= RequestStatus.Failed;
                result.Message = "You dont have any basket. Please, create one first!";

                return result;
             }

            if( dto.UserAddressId==null && dto.OrderNewAddress == null)
            {

                result.Status= RequestStatus.Failed;
                result.Message = "Please, enter adress.";

                return result;

            }

            Order order= new Order();    

            if (dto.UserAddressId <= 0 || dto.UserAddressId == null)
            {
                if(dto.OrderNewAddress == null)
                {
                    result.Status = RequestStatus.Failed;
                    result.Message = "Please, enter valid adress";

                    return result;
                }

                UserAddress address = new UserAddress()
                {
                    Country=dto.OrderNewAddress.Country,
                    City=dto.OrderNewAddress.City,
                    Location=dto.OrderNewAddress.Location,
                    UserId=userId   
                };

                await _UnitOfWork.UserProfileRepository.AddUserAdressAsync(address);
                _UnitOfWork.Commit();
                order.UserAddressId = address.Id;

            }

            else 
            {

                UserAddress adress = await _UnitOfWork.UserProfileRepository.GetUserAddressAsync(userId, dto.UserAddressId);

                if(adress == null)
                {
                    result.Status= RequestStatus.Failed;
                    result.Message = "Please, enter valid adress";

                    return result;
                }

                order.UserAddressId = dto.UserAddressId;
            }


            Basket basket = await _UnitOfWork.UserInteractRepository.GetUserBasketAsync(userId);
          
            order.UserId = basket.UserId;

            if(dto.PaymentType==PaymentType.WithCard) 
            {
                bool IsCard = await _UnitOfWork.ThingsRepository.CheckUserPaymentAsync(userId, dto.CardNumber, dto.CVV, dto.ExpireDate);

                if (!IsCard)
                {

                    result.Status = RequestStatus.Failed;
                    result.Message = "Please, enter valid card";

                    return result;
                }

                order.Products = basket.Products;
                order.TotalPrice = basket.TotalAmount;

                if(dto.PromoCodeId!=null || dto.PromoCodeId >= 1)
                {
                    PromoCode promoCode = await _UnitOfWork.UserInteractRepository.GetPromoCodeAsync(dto.PromoCodeId);

                    if (promoCode.PromoEndTime >= promoCode.PromoStartTime)
                    {
                        result.Status = RequestStatus.Failed;
                        result.Message = "Enter valid PromoCode";

                        return result;
                    }

                    if(promoCode != null) 
                    {
                        double promo = promoCode.PromoDiscount;
                        double multiple = order.TotalPrice * promo;
                        double divide = multiple / 100;
                        order.TotalPrice = promo;
                    }

                }

                await _UnitOfWork.UserInteractRepository.OrderBasketAsync(order, userId);
                _UnitOfWork.Commit();

                await _UnitOfWork.UserInteractRepository.AddOrderHistoryAsync(userId, order.Id);
                _UnitOfWork.Commit();

                if (basket != null)
                {
                    var productQuantities = new List<GetProductsForBasketDTO>();

                    foreach (var group in basket.Products.GroupBy(p => p.Id))
                    {
                        int productId = group.Key;
                        BasketProductQuantity basketQuantity = await _UnitOfWork.UserInteractRepository.GetBasketQuantityAsync(basket.Id, productId);
                        await _UnitOfWork.UserInteractRepository.AddOrderQuantityAsync(order.Id, productId, basketQuantity.Quantity);
                       
                    }

                }

                await _UnitOfWork.UserInteractRepository.DeleteUserBasketAsync(userId);
                      _UnitOfWork.Commit();

                result.Status= RequestStatus.Success;
                result.Message = $"You ordered basket succesfully! Total price is {order.TotalPrice}";

                return result;

            }

            try
            {

                order.Products = basket.Products;
                order.TotalPrice = basket.TotalAmount;

                if (dto.PromoCodeId != null && dto.PromoCodeId >= 1)
                {
                    PromoCode promoCode = await _UnitOfWork.UserInteractRepository.GetPromoCodeAsync(dto.PromoCodeId);

                    if (promoCode != null)
                    {
                        order.TotalPrice = (order.TotalPrice * promoCode.PromoDiscount/100);
                    }
                }

                await _UnitOfWork.UserInteractRepository.OrderBasketAsync(order, userId);
                _UnitOfWork.Commit();

                await _UnitOfWork.UserInteractRepository.AddOrderHistoryAsync(userId, order.Id);
                _UnitOfWork.Commit();


                if (basket != null)
                {
                    var productQuantities = new List<GetProductsForBasketDTO>();

                    foreach (var group in basket.Products.GroupBy(p => p.Id))
                    {
                        int productId = group.Key;
                        BasketProductQuantity basketQuantity = await _UnitOfWork.UserInteractRepository.GetBasketQuantityAsync(basket.Id, productId);
                        await _UnitOfWork.UserInteractRepository.AddOrderQuantityAsync(order.Id, productId, basketQuantity.Quantity);
                        
                       
                    }

                }

                await _UnitOfWork.UserInteractRepository.DeleteUserBasketAsync(userId);
                      _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = $"You ordered basket succesfully! Total price is {order.TotalPrice}";

                return result;

            }
             catch (Exception ex) 
            {
                result.Status = RequestStatus.Failed;
                result.Message = ex.Message;

                return result;
            }
        }

        public async Task<BaseResultDTO> RemoveFavoriteFoodAsync(string token, int FavId)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            int UserId = JwtService.GetIdFromToken(token);

            if (UserId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";
                return result;
            }

            bool IsFood = await _UnitOfWork.ThingsRepository.CheckProductAsync(FavId);

            if (!IsFood)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "This food doesnt exist!";
                return result;
            }

            bool Exist = await _UnitOfWork.ThingsRepository.CheckFavoriteFoodAsync(UserId, FavId);

            if (!Exist)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "This food is not in your favorites";

                return result;
            }

            try
            {
                await _UnitOfWork.UserInteractRepository.DeleteFavFoodAsync(UserId, FavId);
                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "This food deleted from your favorites succesfully!";

                return result;
            }
            catch (Exception ex)
            {
                result.Status = RequestStatus.Failed;
                result.Message = ex.Message;

                return result;

            }
        }

        public async Task<BaseResultDTO> RemoveFavoriteRestaurantAsync(string token, int FavId)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            int UserId = JwtService.GetIdFromToken(token);

            if (UserId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";
                return result;
            }

            bool IsRest = await _UnitOfWork.ThingsRepository.CheckRestaurantAsync(FavId);

            if (!IsRest)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "This restaurant doesnt exist!";
                return result;
            }

            bool Exist = await _UnitOfWork.ThingsRepository.CheckFavoriteRestaurantAsync(UserId, FavId);

            if (!Exist)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "This restaurant is not in your favorites";

                return result;
            }

            try
            {
                await _UnitOfWork.UserInteractRepository.DeleteFavRestaurantAsync(UserId, FavId);
                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "This restaurant deleted from your favorites succesfully!";

                return result;
            }
            catch(Exception ex) 
            {
                result.Status=RequestStatus.Failed;
                result.Message=ex.Message;

                return result;

            }
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

            bool IsAccepted = await _UnitOfWork.ThingsRepository.CheckAcceptedOrderAsync(userId, dto.OrderId);

            if (IsAccepted)
            {
                result.Status=RequestStatus.Failed;
                result.Message = "Since this order is accepted, you cannot cancel Order.";

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

        public async Task<BaseResultDTO> UpdateUserBasketAsync(string token, AddUserBasketDTO dto)
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

            if (!IsBasket)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "You dont have basket. Please, create basket first!";

                return result;
            }

            try
            {
                Basket basket = await _UnitOfWork.UserInteractRepository.GetUserBasketAsync(dto.UserId);
                Product product = await _UnitOfWork.RestaurantRepository.GetProductAsync(dto.ProductId);

                if (product == null)
                {

                    result.Status = RequestStatus.Failed;
                    result.Message = "No Food found!";

                    return result;

                }

                if (dto.Quantity <= 0)
                {
                    result.Status = RequestStatus.Failed;
                    result.Message = "Enter valid quantity. Quantity must be greater than 0";

                    return result;
                }

                for (int i = 0; i < dto.Quantity; i++)
                {
                    
                    basket.Products.Add(product);

                }

                basket.TotalAmount += dto.Quantity * product.Price;
                await _UnitOfWork.UserInteractRepository.AddBasketQuantityAsync(basket.Id, dto.ProductId, dto.Quantity);

                _UnitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = $"You updated basket succesfully! You total amount is {basket.TotalAmount}";

                return result;
            }

            catch (Exception ex)
            {
                result.Status = RequestStatus.Failed;
                result.Message = ex.Message;

                return result;
            }

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
