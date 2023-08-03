﻿using Microsoft.EntityFrameworkCore;
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
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly DataContext _ctx;
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

        public async Task<User> GetAsync(int id)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(c => c.Id == id);

            return user;

        }

        public async Task RegisterUserAsync(User user)
        {
           await  _ctx.Users.AddAsync(user);
        }

    }
}
