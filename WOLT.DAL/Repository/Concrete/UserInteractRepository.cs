using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository.Abstract;
using Wolt.Entities.Enums;

namespace WOLT.DAL.Repository.Concrete
{
    public class UserInteractRepository : IUserInteractRepository
    {
        private readonly DataContext _ctx;
        public UserInteractRepository(DataContext context)
        {
            _ctx = context;
        }

        public async Task AddBasketQuantityAsync(int BasketId, int ProductId, int Quantity)
        {
            BasketProductQuantity basketProductQuantity = _ctx.BasketProductQuantities.FirstOrDefault(c=>c.BasketId==BasketId && c.ProductId==ProductId);

            if(basketProductQuantity!=null) 
            {
                basketProductQuantity.Quantity+=Quantity;
            }

            else
            {
                BasketProductQuantity nEW = new BasketProductQuantity()
                {
                    Quantity=Quantity,
                    BasketId=BasketId,
                    ProductId=ProductId,
                };
               
               await _ctx.BasketProductQuantities.AddAsync(nEW);
            }

        }


        public async Task AddCommentAsync(UserComment comment)
        {

           await _ctx.UserComments.AddAsync(comment);

        }

        public async Task AddFavoriteFoodAsync(FavoriteFood food)
        {
            await _ctx.FavoriteFoods.AddAsync(food);   
        }

        public async Task AddFavoriteRestaurantAsync(FavoriteRestaurant restaurant)
        {
            await _ctx.FavoriteRestaurants.AddAsync(restaurant);
        }

        public async Task AddOrderHistoryAsync(int id, int orderId)
        {
            UserHistory userHistory = await _ctx.UserHistories.FirstOrDefaultAsync(c=>c.UserId==id);
            Order order = await _ctx.Orders.FirstOrDefaultAsync(c=>c.Id==orderId);

            userHistory.Orders.Add(order);
        }

        public async Task AddOrderQuantityAsync(int orderId, int ProductId, int quantity)
        {
            OrderProductQuantity orderQuantity= await  _ctx.OrderProductQuantities.FirstOrDefaultAsync(c=>c.ProductId==ProductId && c.OrderId==orderId);

            if(orderQuantity!=null) 
            {
                orderQuantity.Quantity+=quantity;
            }

            else
            {
                OrderProductQuantity nEW = new OrderProductQuantity() 
                {
                    Quantity= quantity,
                    OrderId=orderId,
                    ProductId=ProductId
                };

                await _ctx.OrderProductQuantities.AddAsync(nEW);
            }
        }

        public async Task AddUserBasketAsync(Basket basket)
        { 
            await _ctx.Baskets.AddAsync(basket);
        }

        public async Task AddUserReviewAsync(UserReview userReview)
        {
            
            await _ctx.UserReviews.AddAsync(userReview);

        }

        public async Task CreateUserHistoryAsync(int id)
        {
            UserHistory userHistory = new UserHistory()
            {
                UserId=id
            };

            await _ctx.UserHistories.AddAsync(userHistory);
        }

        public async Task DeleteCommentAsync(int id, int CommId)
        {
            UserComment comment =  await _ctx.UserComments.Where(c=>c.UserId==id).FirstOrDefaultAsync(c => c.Id==CommId);
            
             _ctx.UserComments.Remove(comment);

        }

        public async Task DeleteFavFoodAsync(int id, int favId)
        {
            FavoriteFood food = await _ctx.FavoriteFoods.FirstOrDefaultAsync(f=>f.UserId==id && f.ProductId==favId);

            _ctx.FavoriteFoods.Remove(food);
        }

        public async Task DeleteFavRestaurantAsync(int id, int favId)
        {
            FavoriteRestaurant fav = await _ctx.FavoriteRestaurants.FirstOrDefaultAsync(r => r.UserId == id && r.RestaurantId == favId);

            _ctx.FavoriteRestaurants.Remove(fav);
        }

        public async Task DeleteReviewAsync(int id, int RevId)
        {
            UserReview review = await _ctx.UserReviews.Where(c=>c.UserId==id).FirstOrDefaultAsync(c=>c.Id==RevId);

            _ctx.UserReviews.Remove(review);
        }

        public async Task DeleteUserBasketAsync(int id)
        {
            Basket basket = await _ctx.Baskets
                .Include(b=>b.Products)
                .FirstOrDefaultAsync(b=>b.UserId==id);

            _ctx.Baskets.Remove(basket);

        }

        public  async Task<List<UserComment>> GetAllCommentsAsync(int id)
        {
            List<UserComment> comments =  await _ctx.UserComments
                .Where(c=>c.UserId==id)
                .Include(c=>c.User)
                .Include(c=>c.Restaurant)
                .ToListAsync();

            return comments;

        }

        public async Task<List<UserReview>> GetAllUserReviewsAsync(int id)
        {
            List<UserReview> reviews = await _ctx.UserReviews
                 .Include(r => r.User)
                 .Include(r => r.Product)
                 .Where(c=>c.UserId==id).ToListAsync();

            return reviews;
        }

        public async Task<BasketProductQuantity> GetBasketQuantityAsync(int basketId, int ProductId)
        {
            BasketProductQuantity productQuantity = await _ctx.BasketProductQuantities.FirstOrDefaultAsync(c=>c.BasketId ==basketId && c.ProductId==ProductId);

            return productQuantity;
        }

        public async Task<UserComment> GetCommentAsync(int id, int commId)
        {
            UserComment comment = await _ctx.UserComments
                .Where(c=>c.UserId==id)
                .Include(c=>c.User)
                .Include(c=>c.Restaurant)
                .FirstOrDefaultAsync(c=>c.Id==commId);

            return comment;
        }

        public async Task<UserComment> GetDeletedCommentFromRestaurantAsync(int id, int RestId)
        {
            UserComment comment = await _ctx.UserComments
               .IgnoreQueryFilters()
              .FirstOrDefaultAsync(c => c.UserId == id && c.RestaurantId == RestId && c.IsDeleted == true);

            return comment;
        }

        public async Task<UserReview> GetDeletedReviewFromProductAsync(int id, int ProductId)
        {
            UserReview review = await _ctx.UserReviews
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c=>c.UserId==id && c.ProductId==ProductId && c.IsDeleted==true);

            return review;
        }

        public async Task<OrderProductQuantity> GetOrderQuantityAsync(int orderId, int ProductId)
        {
            OrderProductQuantity quantity = await _ctx.OrderProductQuantities.FirstOrDefaultAsync(q=>q.ProductId==ProductId && q.OrderId==orderId);

            return quantity;
        }

        public async Task<PromoCode> GetPromoCodeAsync(int? id)
        {
            PromoCode promo = await _ctx.PromoCodes.FirstOrDefaultAsync(c => c.Id == id);

            return promo;
        }

        public async Task<Basket> GetUserBasketAsync(int id)
        {
            Basket basket = await _ctx.Baskets
                .Include(b=>b.Products)
                .FirstOrDefaultAsync(b => b.UserId == id);

            return basket;

        }

        public async Task<UserReview> GetUserReviewAsync(int id, int RevId)
        {
            UserReview review =  await _ctx.UserReviews
                .Include(r=>r.User)
                .Include(r=>r.Product)
                .Where(r=>r.UserId==id).FirstOrDefaultAsync(r=>r.Id==RevId);

            return review;
        }

        public async Task OrderBasketAsync(Order order)
        {

            await _ctx.Orders.AddAsync(order);

        }

        public async Task ReturnOrderAsync(int id, int OrderId, string reason)
        {
            Order order = await _ctx.Orders
                .IgnoreQueryFilters()
                .Where(o => o.UserId == id && !o.IsDeleted && o.OrderStatus==OrderStatus.Waiting)
                .FirstOrDefaultAsync(o=>o.Id==OrderId);

            order.OrderStatus = OrderStatus.Returned;
            order.Description = reason;

            UserHistory history = await _ctx.UserHistories.FirstOrDefaultAsync(h => h.UserId == id);

            User user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id);

            _ctx.Users.Update(user);
            _ctx.Orders.Remove(order);
            _ctx.UserHistories.Update(history);
            
            
     
        }

        public async Task UpdateCommentAsync(int id, int CommId, string desc)
        {
            UserComment comment = await _ctx.UserComments.Where(c=>c.UserId==id).FirstOrDefaultAsync(c=>c.Id==CommId);

            comment.Details = desc;

            _ctx.UserComments.Update(comment);
        }

        public async Task UpdateUserBasketAsync(int id, List<Product> products, int? PromodoCodeId)
        {

            Basket basket = await _ctx.Baskets.FirstOrDefaultAsync(b => b.UserId == id);

            foreach(var item in products)
                basket.Products.Add(item);

            

            _ctx.Baskets.Update(basket);
        }

        public async Task UpdateUserReviewAsync(int id, int RevId, double? score, string? desc)
        {
            UserReview review = await _ctx.UserReviews.Where(r=>r.UserId==id).FirstOrDefaultAsync(r=>r.Id==RevId);

            if (score != null)
                review.Score = score.Value;

            review.Description = desc;

            _ctx.UserReviews.Update(review);

        }
       
    }
}
