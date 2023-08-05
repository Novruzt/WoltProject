using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.BLL.Services.Abstract;
using Wolt.Entities.Entities.UserEntities;
using WOLT.DAL.UnitOfWork.Abstract;

namespace Wolt.BLL.Services.Concrete
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserAuthService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserProfileDTO> GetAsync(int id)
        {

            User user = await  _unitOfWork.UserAuthRepository.GetAsync(id);
            GetUserProfileDTO dto = _mapper.Map<GetUserProfileDTO>(user);

            return dto;
        }

        public Task RegisterUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(int id, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
