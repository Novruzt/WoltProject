using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository.Abstract;

namespace WOLT.DAL.Repository.Concrete
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly DataContext _ctx;

        public UserProfileRepository(DataContext context)
        {
            _ctx = context;
        }

        public async Task AddUserPayment(UserPayment payment)
        {
            await _ctx.UserPayments.AddAsync(payment);
        }

        public async Task DeleteUserPaymentAsync(int id, int PaymentId)
        {
            UserPayment payment = await _ctx.UserPayments.Where(p =>p.UserId == id).FirstOrDefaultAsync(p=>p.Id==PaymentId);

            _ctx.UserPayments.Remove(payment);
        }

        public async Task<List<FavoriteFood>> GetAllFavoriteFoodAsync(int id)
        {
            List<FavoriteFood> favorites =await  _ctx.FavoriteFoods.Where(c=>c.UserId==id).ToListAsync();
            
            return favorites;
        }

        public async Task<List<FavoriteRestaurant>> GetAllFavoriteRestaurantsAsync(int id)
        { 
            List<FavoriteRestaurant> favorites = await _ctx.FavoriteRestaurants.Where(c=>c.UserId== id).ToListAsync();

            return favorites;
        }

        public async Task<List<UserHistory>> GetAllHistoryAsync(int id)
        {
            List<UserHistory> histories = await _ctx.UserHistories.Where(c=>c.UserId== id).ToListAsync();  

            return histories;
        }

        public async Task<List<Order>> GetAllOrdersAsync(int id)
        {
            List<Order> orders = await _ctx.Orders.Where(c=>c.UserId == id).ToListAsync();

            return orders;
        }

        public async Task<List<UserAddress>> GetAllUserAddressesAsync(int id)
        {
            List<UserAddress> datas = await _ctx.UsersAddress.Where(c => c.UserId == id).ToListAsync();

            return datas;
        }

        public async Task<List<UserPayment>> GetAllUserPaymentsAsync(int id)
        {
            List<UserPayment> datas =  await _ctx.UserPayments.Where(c=>c.UserId==id).ToListAsync();

            return datas;
        }

        public async Task<FavoriteFood> GetFavoriteFoodAsync(int id, int favId)
        {
            FavoriteFood data = await _ctx.FavoriteFoods.Where(c => c.UserId == id)
                .Include(f=>f.Product)
                .ThenInclude(p=>p.Category)
                .ThenInclude(c=>c.Restaurant)
                .FirstOrDefaultAsync(c=>c.Id==favId);

            return data;
        }

        public async Task<FavoriteRestaurant> GetFavoriteRestaurantsAsync(int id, int favId)
        {
            FavoriteRestaurant data = await _ctx.FavoriteRestaurants.Where(c=>c.UserId==id).FirstOrDefaultAsync(c=>c.Id==favId);

            return data;
        }

        public async Task<Order> GetOrderAsync(int id, int OrderId)
        {
            Order order = await _ctx.Orders.Where(c => c.UserId == id).FirstOrDefaultAsync(c=>c.Id==id);

            return order;
        }

        public async Task<UserAddress> GetUserAddressesAsync(int id, int addressId)
        {
            UserAddress data = await _ctx.UsersAddress.Where(c=>c.UserId==id).FirstOrDefaultAsync(c=>c.Id==addressId);


            return data;
        }
    }
}
