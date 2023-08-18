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

namespace WOLT.DAL.Repository.Concrete
{
    public class ThingsRepository : IThingsRepository
    {
        private readonly DataContext _ctx;
        public ThingsRepository(DataContext context)
        {
            _ctx = context;
        }

        public async Task<bool> CheckUserCommentForRestaurantAsync(int userId, int restId)
        {
            UserComment comment = await _ctx.UserComments
               .FirstOrDefaultAsync(c => c.UserId == userId && c.RestaurantId==restId);

            if (comment != null)
                return true;
            
            

            return false;
        }

        public async Task<bool> CheckUserForEmailAsync(string email)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null) 
                return true;

            return false;
        }

        public async Task<bool> CheckLoginUserAsync(string email, string password)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if(user != null)
                return true;

            return false;

        }

        public async Task<bool> CheckUserByIdAsync(int Id)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(u=>u.Id==Id);

            if(user != null ) 
                return true;


            return false;

        }

        public async Task<bool> CheckUserOldPassword(int id, string password)
        {
            UserOldPassword old  = await _ctx.UserOldPasswords.FirstOrDefaultAsync(u => u.UserId == id && u.OldPassword == password);

            if(old != null) 
                return true;


            return false;

        }

        public async Task<bool> CheckUserCurrentPassword(int id, string password)
        {
            User user = await  _ctx.Users.FirstOrDefaultAsync(u=>u.Id==id && u.Password==password);

                if( user != null ) 
                    return true;


            return false;
            
        }

        public async Task<bool> CheckUserCommentAsync(int id, int commId)
        {
            UserComment comment = await _ctx.UserComments.FirstOrDefaultAsync(c=>c.UserId==id && c.Id==commId);

            if(comment != null) 
                return true;


            return false;
        }

        public async Task<bool> CheckUserOrderAsync(int id, int orderId)
        {
            Order order  = await _ctx.Orders.FirstOrDefaultAsync(o=> o.Id==orderId && o.UserId==id);

            if(order!= null)
                return true;


            return false;

        }

        public async Task<bool> CheckUserReviewAsync(int userId, int revId)
        {
            UserReview review = await _ctx.UserReviews.FirstOrDefaultAsync(r=>r.Id==revId && r.UserId==userId);

            if(review != null) 
                return true;


            return false;

        }

        public async Task<bool> CheckUserReviewForProductAsync(int userId, int productId)
        {
            UserReview review = await _ctx.UserReviews.FirstOrDefaultAsync(r=>r.UserId==userId && r.ProductId==productId);

            if(review != null) 
                return true;

            return false;
        }

        public async Task<bool> CheckUserBasketAsync(int UserId)
        {
            Basket basket = await _ctx.Baskets.FirstOrDefaultAsync(b=>b.UserId==UserId);

            if(basket != null) 
                return true;

            return false;
        }

        public async Task<bool> CheckProductAsync(int id)
        {
            Product product = await _ctx.Products.FirstOrDefaultAsync(p=>p.Id==id);

            if(product != null)
                return true;

            return false;
        }
    }
}
