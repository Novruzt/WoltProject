using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Configurations;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.UserEntities;
using WOLT.DAL.Repository.Concrete;
using WOLT.DAL.UnitOfWork.Abstract;

namespace Wolt.BLL.Services.Concrete
{
    public class ThingsService : IThingsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
       

        public ThingsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<bool> CheckUserForEmailAsync(string email)
        {
            bool Checker = await _unitOfWork.ThingsRepository.CheckUserForEmailAsync(email);

            if (Checker) 
                return true;

            return false;
                
                    
        }

        public async Task<bool> CheckUserByToken(string token)
        {
           

            int UserId =  JwtService.GetIdFromToken(token);

            bool Checker = await _unitOfWork.ThingsRepository.CheckUserByIdAsync(UserId);

            if (Checker)
                return true;

            return false;


        }

        public async Task<bool> CheckUserCommentForRestaurantAsync(int userId, int restId)
        {

            bool Checker = await _unitOfWork.ThingsRepository.CheckUserCommentForRestaurantAsync(userId, restId);

            if (Checker)
                return true; 

            return false;
        }

        public async Task<bool> CheckLoginUserAsync(string email, string password)
        {
            bool Checker = await _unitOfWork.ThingsRepository.CheckLoginUserAsync(email, password);

            if (Checker) 
                return true;

            return false;
        }
    }
}
