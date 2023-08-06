using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Configurations;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
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

            User user = await _unitOfWork.UserAuthRepository.GetAsync(id);
            GetUserProfileDTO dto = _mapper.Map<GetUserProfileDTO>(user);

            return dto;
        }

        public async Task<GetUserProfileDTO> GetByEmailAsync(string email)
        {
            User user = await _unitOfWork.UserAuthRepository.GetByEmailAsync(email);
            GetUserProfileDTO dto = _mapper.Map<GetUserProfileDTO>(user);

            return dto;
        }

        public async Task<LoginUserResponseDTO> LoginUserAsync(LoginUserRequestDTO dto)
        {

            bool isUser = await _unitOfWork.ThingsRepository.LoginUserAsync(dto.Email, dto.Password);

            LoginUserResponseDTO response = new LoginUserResponseDTO();

            if (isUser)
            {

                User user = await _unitOfWork.UserAuthRepository.GetByEmailAsync(dto.Email);

                response.Result = true;
                response.Token = user.Token;

                int UserId = JwtService.GetIdFromToken(user.Token);

                bool IsToken = await _unitOfWork.ThingsRepository.GetUserByIdAsync(UserId);

                if (!IsToken)
                {

                    response.Token = JwtService.CreateToken(user);
                    user.Token = response.Token;

                    _unitOfWork.Commit();
                }


            }

            return response;
        }

        public async Task<RegisterUserResponseDTO> RegisterUserAsync(RegisterUserRequestDTO newUser)
        {
            User user = _mapper.Map<User>(newUser);

            RegisterUserResponseDTO response = new RegisterUserResponseDTO()
            {

                Token = JwtService.CreateToken(user),
                Result = true

            };

            user.Token = response.Token;

            await _unitOfWork.UserAuthRepository.RegisterUserAsync(user);

            _unitOfWork.Commit();

            UserOldPassword oldPassword = new UserOldPassword() {
                OldPassword = user.Password,
                UserId = user.Id
            };

            await _unitOfWork.UserAuthRepository.AddOldPasswordAsync(oldPassword);

            _unitOfWork.Commit();

            return response;
        }

        public async Task<string> ResetPasswordAsync(int id, ResetPasswordRequestDTO dto)
        {
           

            if(dto.Password==dto.newPassword) 
               return  "New Password cannot be same as old passwords.";

            if (dto.newPassword != dto.PassAgain)
               return "Passwords must be same";

            bool CheckOldPassword = await _unitOfWork.ThingsRepository.GetUserOldPassword(id, dto.newPassword);

            if (CheckOldPassword)
                return "New Password cannot be same as old passwords.";

            bool CheckCurrent=  await _unitOfWork.ThingsRepository.GetUserCurrentPassword(id, dto.Password);
            if (!CheckCurrent)
                return "Enter Current Password";
            
            await _unitOfWork.UserAuthRepository.ResetPasswordAsync(id, dto.newPassword);

            _unitOfWork.Commit();
                return "You changed password succesfully!";

         
        }
    }
}
