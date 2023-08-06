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

        public async Task<bool> GetUserCommentAsync(int userId, int restId)
        {
            UserComment comment = await _ctx.UserComments
               .FirstOrDefaultAsync(c => c.UserId == userId && c.RestaurantId==restId);

            if (comment != null)
                return true;
            
            

            return false;
        }

        public async Task<bool> GetUserAsync(string email)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null) 
                return true;

            return false;
        }

        public async Task<bool> LoginUserAsync(string email, string password)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if(user != null)
                return true;

            return false;

        }

        public async Task<bool> GetUserByIdAsync(int Id)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(u=>u.Id==Id);

            if(user != null ) 
                return true;


            return false;

        }

        public async Task<bool> GetUserOldPassword(int id, string password)
        {
            UserOldPassword old  = await _ctx.UserOldPasswords.FirstOrDefaultAsync(u => u.UserId == id && u.OldPassword == password);

            if(old != null) 
                return true;


            return false;

        }

        public async Task<bool> GetUserCurrentPassword(int id, string password)
        {
            User user = await  _ctx.Users.FirstOrDefaultAsync(u=>u.Id==id && u.Password==password);

                if( user != null ) 
                    return true;


            return false;
            
        }
    }
}
