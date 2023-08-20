using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using Wolt.Entities.Enums;
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

        public async Task AddFavoriteFoodAsync(FavoriteFood food)
        {
            await _ctx.FavoriteFoods.AddAsync(food);
        }

        public async Task AddFavoriteRestaurantAsync(FavoriteRestaurant restaurant)
        {
            await _ctx.FavoriteRestaurants.AddAsync(restaurant);
        }

        public async Task AddUserAdressAsync(UserAddress address)
        {
            await _ctx.UsersAddress.AddAsync(address);
        }

        public async Task AddUserPayment(UserCard payment)
        {
            await _ctx.UserPayments.AddAsync(payment);
        }

        public async Task DeleteUserPaymentAsync(int id, int PaymentId)
        {
            UserCard payment = await _ctx.UserPayments.Where(p =>p.UserId == id).FirstOrDefaultAsync(p=>p.Id==PaymentId);

            _ctx.UserPayments.Remove(payment);
        }

        public async Task<List<FavoriteFood>> GetAllFavoriteFoodAsync(int id)
        {
            List<FavoriteFood> favorites =await  _ctx.FavoriteFoods.Where(c=>c.UserId==id)
                .Include(ff=>ff.Product)
                .ToListAsync();
            
            return favorites;
        }

        public async Task<List<FavoriteRestaurant>> GetAllFavoriteRestaurantsAsync(int id)
        { 
            List<FavoriteRestaurant> favorites = await _ctx.FavoriteRestaurants.Where(c=>c.UserId== id)
                .Include(fr=>fr.Restaurant)
                .ToListAsync();

            return favorites;
        }

        public async Task<List<Order>> GetAllHistoryAsync(int id)
        {

            List<Order> orders = await _ctx.Orders.Where(o=>o.UserId==id)
                .IgnoreQueryFilters()
                .Where(o=>o.IsDeleted==false)
                .Include(o=>o.UserAddress)
                .ToListAsync();

            return orders;
        }

        public async Task<List<Order>> GetAllOrdersAsync(int id)
        {
            List<Order> orders = await _ctx.Orders.Where(c=>c.UserId == id && c.IsDeleted == false)
                .IgnoreQueryFilters()
                .Where(o=>o.OrderStatus==OrderStatus.Waiting || o.OrderStatus==OrderStatus.Accepted) 
                .Include(o=>o.UserAddress)
                .ToListAsync();

            return orders;
        }

        public async Task<List<UserAddress>> GetAllUserAddressesAsync(int id)
        {
            List<UserAddress> datas = await _ctx.UsersAddress.Where(c => c.UserId == id).ToListAsync();

            return datas;
        }

        public async Task<List<UserCard>> GetAllUserPaymentsAsync(int id)
        {
            List<UserCard> datas =  await _ctx.UserPayments.Where(c=>c.UserId==id).ToListAsync();

            return datas;
        }

        public async Task<FavoriteFood> GetFavoriteFoodAsync(int id, int favId)
        {
            FavoriteFood data = await _ctx.FavoriteFoods.Where(c => c.UserId == id)
                .Include(f=>f.Product)
                .ThenInclude(p=>p.Category)
                .ThenInclude(c=>c.Restaurant)
                .FirstOrDefaultAsync(c=>c.ProductId==favId);

            return data;
        }

        public async Task<FavoriteRestaurant> GetFavoriteRestaurantsAsync(int id, int favId)
        {
            FavoriteRestaurant data = await _ctx.FavoriteRestaurants.Where(c=>c.UserId==id)
                .Include(fr=>fr.Restaurant)
                .ThenInclude(r=>r.Categories)
                .FirstOrDefaultAsync(c=>c.RestaurantId==favId);

            return data;
        }

        public async Task<Order> GetOrderAsync(int id, int OrderId)
        {
            Order order = await _ctx.Orders.Where(c => c.UserId == id)
                .Include(o=>o.Products)
                .ThenInclude(p=>p.Category)
                .Include(o=>o.UserAddress)
                .FirstOrDefaultAsync(c=>c.Id==OrderId);

            return order;
        }

        public async Task<UserAddress> GetUserAddressAsync(int id, int? adressId)
        {
            UserAddress adress= await _ctx.UsersAddress.FirstOrDefaultAsync(a=>a.UserId==id && a.Id==adressId);

            return adress;
        }

        public async Task<UserHistory> GetUserHistory(int id)
        {
            var userHistory = await _ctx.UserHistories
                .AsNoTracking()
                .Where(h => h.IsDeleted == false)
                .FirstOrDefaultAsync(h => h.UserId == id);

            if (userHistory != null)
            {
               
                _ctx.Entry(userHistory)
                    .Collection(uh => uh.Orders)
                    .Query()
                    .IgnoreQueryFilters()
                    .Load();
            }

            return userHistory;
        }
    }
}
