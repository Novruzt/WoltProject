using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository.Abstract;
using WOLT.DAL.UnitOfWork.Abstract;

namespace WOLT.DAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRestaurantRepository RestaurantRepository { get; set; }
        public IUserAuthRepository UserAuthRepository { get; set; }
        public IUserInteractRepository UserInteractRepository { get; set; }
        public IUserProfileRepository UserProfileRepository { get; set; }
        public IThingsRepository ThingsRepository { get; set; }
        private IDbContextTransaction _CurrentTransaction;

        private readonly DataContext _context;
        public UnitOfWork(IUserProfileRepository profile, IUserInteractRepository interact, IUserAuthRepository auth, 
            IRestaurantRepository restaurant,IThingsRepository things, DataContext context)
        {

            UserProfileRepository = profile;
            UserInteractRepository = interact;
            UserAuthRepository = auth;
            RestaurantRepository = restaurant;
            ThingsRepository = things;

            _context= context;

        }

        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            if (_CurrentTransaction == null)
                _CurrentTransaction = await _context.Database.BeginTransactionAsync(); 
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                
                await _CurrentTransaction.CommitAsync();
                await _CurrentTransaction.DisposeAsync();
            }
            catch
            {
               await  RollbackTransactionAsync();
               throw;
            }
            finally
            {
                if (_CurrentTransaction != null)
                {
                   await _CurrentTransaction.DisposeAsync();
                    _CurrentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {

                if (_CurrentTransaction != null)
                {
                    await _CurrentTransaction.RollbackAsync();
                    await _CurrentTransaction.DisposeAsync();
                    _CurrentTransaction = null;
                }
            }

            catch
            {
                
                throw;
            }
        }
    }
}
