using AutoMapper;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Wolt.BLL.Configurations;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.BLL.DTOs.UserInteractDTOs;
using Wolt.BLL.Enums;
using Wolt.BLL.Exceptions;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using Wolt.Entities.Enums;
using WOLT.DAL.UnitOfWork.Abstract;
using WOLT.DAL.UnitOfWork.Concrete;
using UnauthorizedAccessException = Wolt.BLL.Exceptions.UnauthorizedAccessException;

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
        public async Task AddCommentAsync(string token,AddUserCommentDTO comment)
        {

            comment.UserId = JwtService.GetIdFromToken(token);

            bool IsRestaurant = await _UnitOfWork.ThingsRepository.CheckRestaurantAsync(comment.RestaurantId);

             if (!IsRestaurant)
                throw new NotFoundException("No Restaurant Found");

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserCommentForRestaurantAsync(comment.UserId,comment.RestaurantId);

            if (IsComment)
                 throw new AlreadyDoneException("You already have commented for this restaurant");

            try
            {
                await _UnitOfWork.BeginTransactionAsync();
                bool IsDeleted = await _UnitOfWork.ThingsRepository.CheckDeletedCommentForRestaurantAsync(comment.UserId, comment.RestaurantId);

                if (IsDeleted)
                {
                    UserComment userComment = await _UnitOfWork.UserInteractRepository.GetDeletedCommentFromRestaurantAsync(comment.UserId, comment.RestaurantId);

                    userComment.Details = comment.Details;
                    userComment.IsDeleted = false;

                 
                }

                else
                {
                    UserComment data = _mapper.Map<UserComment>(comment);

                    await _UnitOfWork.UserInteractRepository.AddCommentAsync(data);
                }

                await _UnitOfWork.CommitAsync();
                await _UnitOfWork.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await _UnitOfWork.RollbackTransactionAsync();
                throw new BadRequestException(ex);
            }

        }

        public async Task AddFavoriteFoodAsync(string token, int FavId)
        {

            int UserId = JwtService.GetIdFromToken(token);

            bool IsFood = await _UnitOfWork.ThingsRepository.CheckProductAsync(FavId);

            if (!IsFood)
                throw new NotFoundException("No food found");

            bool Exist = await _UnitOfWork.ThingsRepository.CheckFavoriteFoodAsync(UserId, FavId);

            if (Exist)
                throw new AlreadyDoneException("This food already is in your favorites");

            try
            {
                await _UnitOfWork.BeginTransactionAsync();
                FavoriteFood food = new FavoriteFood()
                {
                    UserId=UserId,
                    ProductId=FavId
                };

                await _UnitOfWork.UserInteractRepository.AddFavoriteFoodAsync(food);

                await _UnitOfWork.CommitTransactionAsync();
                await  _UnitOfWork.CommitAsync();

            }

            catch (Exception ex) 
            {
                await _UnitOfWork.RollbackTransactionAsync();
                throw new BadRequestException(ex);
            }
        }

        public async Task AddFavoriteRestaurantAsync(string token, int FavId)
        {

            int UserId = JwtService.GetIdFromToken(token);

            bool IsRest = await _UnitOfWork.ThingsRepository.CheckRestaurantAsync(FavId);

            if (!IsRest)
                throw new NotFoundException("This restaurant doesn't exists");

            bool Exist = await _UnitOfWork.ThingsRepository.CheckFavoriteRestaurantAsync(UserId, FavId);

            if (Exist)
             throw new AlreadyDoneException("This restaurant is already in your favorites");

            try
            {
                await _UnitOfWork.BeginTransactionAsync();
                FavoriteRestaurant fav = new FavoriteRestaurant()
                {
                    UserId = UserId,
                    RestaurantId= FavId
                };

                await _UnitOfWork.UserInteractRepository.AddFavoriteRestaurantAsync(fav);

                await _UnitOfWork.CommitTransactionAsync();
                await _UnitOfWork.CommitAsync();

            }

            catch (Exception ex)
            {
                await _UnitOfWork.RollbackTransactionAsync();
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task AddUserBasketAsync(string token, AddUserBasketDTO dto)
        {
            dto.UserId = JwtService.GetIdFromToken(token);
           
                try
                {
                    await _UnitOfWork.BeginTransactionAsync();
                    bool IsBasket = await _UnitOfWork.ThingsRepository.CheckUserBasketAsync(dto.UserId);

                    if (IsBasket)
                        throw new AlreadyDoneException("You already have a basket");

                    Basket basket = new Basket()
                    {
                        UserId = dto.UserId
                    };

                    Product product = await _UnitOfWork.RestaurantRepository.GetProductAsync(dto.ProductId);

                    if (product == null)
                        throw new NotFoundException("No food found");

                    if (dto.Quantity <= 0)
                        throw new BadRequestException("Enter a valid quantity. Quantity must be greater than 0");

                    for (int i = 0; i < dto.Quantity; i++)
                    {
                        basket.Products.Add(product);
                    }

                    basket.TotalAmount = dto.Quantity * product.Price;
                    dto.TotalAmount = basket.TotalAmount;

                    await _UnitOfWork.UserInteractRepository.AddUserBasketAsync(basket);
                    await _UnitOfWork.CommitAsync();
                   
                    await _UnitOfWork.UserInteractRepository.AddBasketQuantityAsync(basket.Id, dto.ProductId, dto.Quantity);

                    await _UnitOfWork.CommitTransactionAsync();
                    await _UnitOfWork.CommitAsync();

                
                }
                catch (Exception ex)
                {
                    await _UnitOfWork.RollbackTransactionAsync();
                    throw new BadRequestException(ex.Message);
                }
         
        }

        public async Task AddUserReviewAsync(string token, AddUserReviewDTO dto)
        {
          
            dto.UserId = JwtService.GetIdFromToken(token);

            bool IsFood = await _UnitOfWork.ThingsRepository.CheckProductAsync(dto.ProductId);

            if (!IsFood)
                throw new NotFoundException("No Food found");

            bool IsReview = await _UnitOfWork.ThingsRepository.CheckUserReviewForProductAsync(dto.UserId, dto.ProductId);

            if (IsReview)
                throw new AlreadyDoneException("You already have reviewed for this product");

            try
            {
                await _UnitOfWork.BeginTransactionAsync();

                bool IsDeleted = await _UnitOfWork.ThingsRepository.CheckDeletedReviewForProductAsync(dto.UserId, dto.ProductId);

                if (IsDeleted) 
                {

                    UserReview userReview = await _UnitOfWork.UserInteractRepository.GetDeletedReviewFromProductAsync(dto.UserId, dto.ProductId);

                    userReview.IsDeleted = false;
                    userReview.Score = dto.Score;
                    userReview.Description = dto.Description;

                 

                }

                else
                {
                    UserReview review = _mapper.Map<UserReview>(dto);

                    await _UnitOfWork.UserInteractRepository.AddUserReviewAsync(review);
                   
                }

                await _UnitOfWork.CommitAsync();
                await _UnitOfWork.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await _UnitOfWork.RollbackTransactionAsync();
                throw new BadRequestException(ex);
            }
        }

        public async Task DeleteCommentAsync(string token, int CommId)
        {
        
            int userId = JwtService.GetIdFromToken(token);

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserCommentAsync(userId, CommId);

            if (!IsComment)
                throw new NotFoundException("No Comment Found");
            

            try
            { 
                await _UnitOfWork.UserInteractRepository.DeleteCommentAsync(userId, CommId);

                await  _UnitOfWork.CommitAsync();

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex);
            }

        }

        public async Task DeleteUserBasketAsync(string token)
        {
           
           int userId = JwtService.GetIdFromToken(token);

            bool IsBasket = await _UnitOfWork.ThingsRepository.CheckUserBasketAsync(userId);

            if (!IsBasket)
                throw new NotFoundException("No basket found");

            try
            {

                await _UnitOfWork.UserInteractRepository.DeleteUserBasketAsync(userId);

                await _UnitOfWork.CommitAsync();

            }

            catch (Exception ex) 
            {
                throw new BadRequestException(ex);
            }
        }

        public async Task DeleteUserReviewAsync(string token, int revId)
        {

            int userId = JwtService.GetIdFromToken(token);

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserReviewAsync(userId, revId);

            if (!IsComment)
                throw new NotFoundException("No Review Found!");

            try
            {

                await _UnitOfWork.UserInteractRepository.DeleteReviewAsync(userId, revId);

                await  _UnitOfWork.CommitAsync();
 
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex);
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

        public  async Task OrderBasketAsync(string token, OrderBasketDTO dto)    
        {

            await _UnitOfWork.BeginTransactionAsync();
            int userId = JwtService.GetIdFromToken(token);

            bool IsBasket = await _UnitOfWork.ThingsRepository.CheckUserBasketAsync(userId);

            if (!IsBasket)
                throw new NotFoundException("You dont have any basket. Please, create one first!");

            Order order = new Order()
            {
                UserId = userId
            };    

            Basket basket = await _UnitOfWork.UserInteractRepository.GetUserBasketAsync(userId);
          
            order.UserId = basket.UserId;

            if (dto.PaymentType == PaymentType.WithCard)
            {
                bool IsCard = await _UnitOfWork.ThingsRepository.CheckUserPaymentAsync(userId, dto.CardNumber, dto.CVV, dto.ExpireDate);

                if (!IsCard)
                    throw new NotFoundException("Please, enter valid card");
            }

                if (dto.UserAddressId == null && dto.OrderNewAddress == null)
                    throw new BadRequestException("Please, enter adress.");

                if (dto.UserAddressId >= 0 && dto.OrderNewAddress != null)
                    throw new BadRequestException("Please, enter only one adress");

                if (dto.UserAddressId <= 0 || dto.UserAddressId == null)
                {
                    if (dto.OrderNewAddress == null)
                        throw new BadRequestException("Please, enter valid adress");


                    UserAddress address = new UserAddress()
                    {
                        Country = dto.OrderNewAddress.Country,
                        City = dto.OrderNewAddress.City,
                        Location = dto.OrderNewAddress.Location,
                        UserId = userId
                    };

                    await _UnitOfWork.UserProfileRepository.AddUserAdressAsync(address);
                    await  _UnitOfWork.CommitAsync();
                    order.UserAddressId = address.Id;

                }

                else
                {

                    UserAddress adress = await _UnitOfWork.UserProfileRepository.GetUserAddressAsync(userId, dto.UserAddressId);

                    if (adress == null)
                        throw new NotFoundException("Please, enter valid adress");

                    order.UserAddressId = dto.UserAddressId;
                }


            order.Products = basket.Products;
            order.TotalPrice = basket.TotalAmount;

            if (dto.PromoCodeId != null)
            {
                PromoCode promoCode = await _UnitOfWork.UserInteractRepository.GetPromoCodeAsync(dto.PromoCodeId);

                if (promoCode == null)
                    throw new NotFoundException("Enter valid PromoCode");

                if (promoCode.PromoEndTime <= promoCode.PromoStartTime)
                    throw new NotFoundException("Enter valid PromoCode");

                if (promoCode != null)
                {
                    order.TotalPrice = order.TotalPrice - (order.TotalPrice * (promoCode.PromoDiscount / 100));
                }

            }

            try
            {
                order.OrderDate= DateTime.Now;
                await _UnitOfWork.UserInteractRepository.OrderBasketAsync(order);
                await _UnitOfWork.CommitAsync();

                await _UnitOfWork.UserInteractRepository.AddOrderHistoryAsync(userId, order.Id);
                await _UnitOfWork.CommitAsync();

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
                await _UnitOfWork.CommitAsync();


                await _UnitOfWork.CommitTransactionAsync();
                await  _UnitOfWork.CommitAsync();

                dto.OrderTotalPrice=order.TotalPrice;

            }
             catch (Exception ex) 
            {
                await _UnitOfWork.RollbackTransactionAsync();
                throw new BadRequestException(ex);
            }

           
        }

        public async Task RemoveFavoriteFoodAsync(string token, int FavId)
        {
           
            int UserId = JwtService.GetIdFromToken(token);

            bool IsFood = await _UnitOfWork.ThingsRepository.CheckProductAsync(FavId);

            if (!IsFood)
                throw new NotFoundException("This food doesn't exists");

            bool Exist = await _UnitOfWork.ThingsRepository.CheckFavoriteFoodAsync(UserId, FavId);

            if (!Exist)
                throw new AlreadyDoneException("This food is not in your favorites");

            try
            {
                await _UnitOfWork.UserInteractRepository.DeleteFavFoodAsync(UserId, FavId);
                await _UnitOfWork.CommitAsync();

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex);
            }
        }

        public async Task RemoveFavoriteRestaurantAsync(string token, int FavId)
        {
           
            int UserId = JwtService.GetIdFromToken(token);

            bool IsRest = await _UnitOfWork.ThingsRepository.CheckRestaurantAsync(FavId);

            if (!IsRest)
                throw new NotFoundException("This restaurant doesnt exist!");

            bool Exist = await _UnitOfWork.ThingsRepository.CheckFavoriteRestaurantAsync(UserId, FavId);

            if (!Exist)
                throw new NotFoundException("This restaurant is not in your favorites");

            try
            {
                await _UnitOfWork.UserInteractRepository.DeleteFavRestaurantAsync(UserId, FavId);
                await _UnitOfWork.CommitAsync();

            }
            catch(Exception ex) 
            {
                throw new BadRequestException(ex);
            }
        }

        public async Task ReturnOrderAsync(string token, ReturnOrderDTO dto)
        {

            int userId = JwtService.GetIdFromToken(token);

            bool IsOrder = await _UnitOfWork.ThingsRepository.CheckUserOrderAsync(userId, dto.OrderId);

            if (!IsOrder)
                throw new NotFoundException("No Order Found!");

            bool IsAccepted = await _UnitOfWork.ThingsRepository.CheckAcceptedOrderAsync(userId, dto.OrderId);

            if (IsAccepted)
                throw new AlreadyDoneException("Since this order is accepted, you cannot cancel Order.");

            try
            {
                await _UnitOfWork.UserInteractRepository.ReturnOrderAsync(userId, dto.OrderId, dto.Reason);

                await _UnitOfWork.CommitAsync();
 
            }

            catch (Exception ex) 
            {
                throw new BadRequestException(ex);
            }

        }

        public async Task UpdateCommentAsync(string token, UpdateCommentDTO dto)
        {
          
            int userId = JwtService.GetIdFromToken(token);

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserCommentAsync(userId, dto.commId);

            if (!IsComment)
                throw new NotFoundException("No Comment Found!");
                
            try
            {

                await _UnitOfWork.UserInteractRepository.UpdateCommentAsync(userId, dto.commId, dto.desc);
                await _UnitOfWork.CommitAsync();

               
            }
            catch(Exception ex)
            { 
                throw new BadRequestException(ex);
            }

        }

        public async Task UpdateUserBasketAsync(string token, AddUserBasketDTO dto)
        {
            dto.UserId = JwtService.GetIdFromToken(token);

            bool IsBasket = await _UnitOfWork.ThingsRepository.CheckUserBasketAsync(dto.UserId);

            if (!IsBasket)
                throw new NotFoundException("You dont have basket. Please, create basket first!");
            try
            {
                Basket basket = await _UnitOfWork.UserInteractRepository.GetUserBasketAsync(dto.UserId);
                Product product = await _UnitOfWork.RestaurantRepository.GetProductAsync(dto.ProductId);

                if (product == null)
                    throw new NotFoundException("No Food found!");

                if (dto.Quantity <= 0)
                    throw new BadRequestException("Enter valid quantity. Quantity must be greater than 0");

                for (int i = 0; i < dto.Quantity; i++)
                    basket.Products.Add(product);


                basket.TotalAmount += dto.Quantity * product.Price;
                await _UnitOfWork.UserInteractRepository.AddBasketQuantityAsync(basket.Id, dto.ProductId, dto.Quantity);

                await _UnitOfWork.CommitAsync();

                dto.TotalAmount=basket.TotalAmount;
            }

            catch (Exception ex)
            {
                throw new BadRequestException(ex);
            }
           

        }

        public async Task UpdateUserReviewAsync(string token, UpdateReviewDTO dto)
        {
           
            int userId = JwtService.GetIdFromToken(token);

            bool IsComment = await _UnitOfWork.ThingsRepository.CheckUserReviewAsync(userId, dto.revId);

            if (!IsComment)
                throw new NotFoundException("No Review Found!");

            try
            {

                await _UnitOfWork.UserInteractRepository.UpdateUserReviewAsync(userId, dto.revId, dto.Score, dto.Description);
                await _UnitOfWork.CommitAsync();

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex);
            }
        }

    }
}
