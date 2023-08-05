using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace WOLT.DAL.Repository.Abstract
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllAsync();
        Task<Restaurant> GetAsync(int id);
        Task<List<Category>> GetAllCategoriesAsync(int id);
        Task<Category> GetCategoryAsync(int id);
        Task<List<Product>> GetAllProductsAsync(int id);
        Task<Product> GetProductAsync(int id);
        Task<List<UserComment>> GetAllCommentsAsync(int id);
        Task<List<UserReview>> GetUserReviewsAsync(int id);
        
        
    }
}
