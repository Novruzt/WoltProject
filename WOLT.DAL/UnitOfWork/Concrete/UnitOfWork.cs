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

        public  void Commit()
        {
            _context.SaveChanges(); 
        }
    }
}
