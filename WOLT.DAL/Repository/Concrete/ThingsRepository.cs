using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;
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

        public async Task<UserComment> GetUserCommentAsync(int userId, int restId)
        {
            UserComment comment = await _ctx.UserComments
               .FirstOrDefaultAsync(c => c.UserId == userId && c.RestaurantId==restId);

            return comment;
        }
    }
}
