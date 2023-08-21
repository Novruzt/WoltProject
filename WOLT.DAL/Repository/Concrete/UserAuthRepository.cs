using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository.Abstract;

namespace WOLT.DAL.Repository.Concrete
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly DataContext _ctx;
        public UserAuthRepository(DataContext context)
        {
            _ctx = context;
        }
        public async Task DeleteUserAsync(int id)
        {
            User user  = await _ctx.Users.FirstOrDefaultAsync(c => c.Id == id);

            _ctx.Users.Remove(user);

        }

        public async Task ResetPasswordAsync(int id, string newPassword)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id);

            user.Password=newPassword;

            _ctx.Users.Update(user);

        }

        public async Task<User> GetByEmailAsync(string email)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(c => c.Email == email);

            return user;

        }

        public async Task RegisterUserAsync(User user)
        {
           await  _ctx.Users.AddAsync(user);
          
        }

        public async Task<User> GetAsync(int id)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(c => c.Id == id);

            return user;

        }

        public async Task AddOldPasswordAsync(UserOldPassword userOld)
        {
            await _ctx.AddAsync(userOld);
        }

        public  async Task ChangeProfilePictureAsync(int id, string? path)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            
                if (path != null)
                    user.ProfilePicture = path; 

                else
                    user.ProfilePicture=null;
               

        }
    }
}
