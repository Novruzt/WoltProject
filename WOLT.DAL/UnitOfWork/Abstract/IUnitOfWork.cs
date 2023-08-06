using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository.Abstract;

namespace WOLT.DAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        public IRestaurantRepository RestaurantRepository { get; }
        public IUserAuthRepository UserAuthRepository { get; }
        public IUserInteractRepository UserInteractRepository { get; }
        public IUserProfileRepository UserProfileRepository { get; }
        public IThingsRepository ThingsRepository { get; }
        public void Commit();
    }
}
