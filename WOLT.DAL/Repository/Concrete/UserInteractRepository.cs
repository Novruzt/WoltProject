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
        public async Task AddCommentAsync(UserComment comment)
        {

           await _ctx.UserComments.AddAsync(comment);

        }

        public async Task AddUserBasketAsync(Basket basket)
        {

            basket.TotalAmount = CalculateTotalAmount(basket.Products, basket.PromoCodeId);
            

            await _ctx.Baskets.AddAsync(basket);
        }

        public async Task AddUserReviewAsync(UserReview userReview)
        {
            
            await _ctx.UserReviews.AddAsync(userReview);

        }

        public async Task DeleteComment(int id, int CommId)
        {
            UserComment comment =  await _ctx.UserComments.Where(c=>c.UserId==id).FirstOrDefaultAsync(c => c.Id==CommId);
            
             _ctx.UserComments.Remove(comment);

        }

        public async Task DeleteUserBasket(int id)
        {
            Basket basket = await _ctx.Baskets.FirstOrDefaultAsync(b=>b.UserId==id);

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
            List<UserReview> reviews = await _ctx.UserReviews.Where(c=>c.UserId==id).ToListAsync();

            return reviews;
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

        public async Task<UserReview> GetUserReviewAsync(int id, int RevId)
        {
            UserReview review =  await _ctx.UserReviews.Where(r=>r.UserId==id).FirstOrDefaultAsync(r=>r.Id==RevId);

            return review;
        }

        public async Task ReturnOrderAsync(int id, int OrderId, string reason)
        {
            Order order = await _ctx.Orders
                .IgnoreQueryFilters()
                .Where(o => o.UserId == id && !o.IsDeleted).FirstOrDefaultAsync(o=>o.Id==OrderId);

            order.OrderStatus = OrderStatus.Returned;
            order.Description = reason;
            order.DeleteTime=DateTime.Now;

            UserHistory history = await _ctx.UserHistories.FirstOrDefaultAsync(h => h.UserId == id);

            history.Orders.Add(order);

            User user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id);

            _ctx.Users.Update(user);
            _ctx.Orders.Update(order);
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

            if(PromodoCodeId!=null && PromodoCodeId!=0 && basket.PromoCodeId!=null)
                basket.PromoCodeId=PromodoCodeId.Value;

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

        private double CalculateTotalAmount(ICollection<Product> products, int? promoCodeId)
        {
            double totalAmount = products.Sum(p => p.Price);

            if (promoCodeId.HasValue && promoCodeId.Value>0)
            {
                var promoCode = _ctx.PromoCodes.FirstOrDefault(p => p.Id == promoCodeId.Value);
                if (promoCode != null)
                {
                    totalAmount = totalAmount - (totalAmount * promoCode.PromoDiscount / 100);
                }
            }

            return totalAmount;
        }

       
    }
}
