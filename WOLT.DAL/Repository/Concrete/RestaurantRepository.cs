using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository.Abstract;

namespace WOLT.DAL.Repository.Concrete
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DataContext _ctx;

        public async Task<List<Restaurant>> GetAllAsync()
        {
           List<Restaurant> datas  = await _ctx.Restaurants.ToListAsync();

            return datas;
        }

        public async Task<List<Branch>> GetAllBranchesAsync(int id)
        {
            List<Branch> datas = await _ctx.Branches
                .Where(c=>c.RestaurantId== id)
                .ToListAsync();

            return datas;
        }

        public async Task<List<Category>> GetAllCategoriesAsync(int id)
        {
            List<Category> datas = await _ctx.Categories
                .Where(c=>c.RestaurantId==id)
                .ToListAsync();

            return datas;
        }

        public async Task<List<Product>> GetAllProductsAsync(int id)
        {

            List<Product> datas = await _ctx.Products
                .Where(c => c.CategoryId == id)
                .ToListAsync();

            return datas;
        }

        public async Task<List<UserComment>> GetAllCommentsAsync(int id)
        {
            List<UserComment> datas = await _ctx.UserComments
                .Where(c => c.RestaurantId == id)
                .ToListAsync();

            return datas;
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            Restaurant data = await _ctx.Restaurants.FirstOrDefaultAsync(c=>c.Id==id);

            return data;
        }

        public async Task<Branch> GetBranchAsync(int id)
        {
            Branch data = await _ctx.Branches.FirstOrDefaultAsync(b=>b.Id==id);

            return data;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
           Category data  =  await _ctx.Categories.FirstOrDefaultAsync(d=>d.Id==id);

            return data;
        }

        public async Task<Product> GetProductAsync(int id)
        {
           Product data = await _ctx.Products.FirstOrDefaultAsync(c=>c.Id == id);

            return data;
        }

        public async Task<List<UserReview>> GetUserReviewsAsync(int id)
        {
            List<UserReview> datas = await _ctx.UserReviews
                .Where(c => c.ProductId == id)
                .ToListAsync();

            return datas;
        }
    }
}
