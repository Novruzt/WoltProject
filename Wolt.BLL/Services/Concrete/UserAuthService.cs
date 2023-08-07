﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Configurations;
using Wolt.BLL.DTOs.ThingsDTO;
using Wolt.BLL.DTOs.UserAuthDTOs;
using Wolt.BLL.Enums;
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

        public async Task<BaseResultDTO> ForgotPasswordAsync(int id, ForgotPasswordRequestDTO dto)
        {
            BaseResultDTO result = new BaseResultDTO();
             User user  =await  _unitOfWork.UserAuthRepository.GetAsync(id);

            if (user.Email != dto.Email)
            {
                result.Status=RequestStatus.Failed;
                result.Message = "Wrong email";

                return result;
            }
               

            bool CheckOldPassword = await _unitOfWork.ThingsRepository.CheckUserOldPassword(id, dto.newPassword);

            if (CheckOldPassword)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "New Password cannot be same as old passwords.";

                return result;
            }
               


            //Not Finished Do later.


            
            result.Status = RequestStatus.Success;
            result.Message = "Done!";

            return result;

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

            bool isUser = await _unitOfWork.ThingsRepository.CheckLoginUserAsync(dto.Email, dto.Password);

            LoginUserResponseDTO response = new LoginUserResponseDTO();

            if (isUser)
            {

                User user = await _unitOfWork.UserAuthRepository.GetByEmailAsync(dto.Email);

                response.Result = true;
                response.Token = user.Token;

                bool IsToken = JwtService.ValidateToken(user.Token);

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

        public async Task<BaseResultDTO> ResetPasswordAsync(int id, ResetPasswordRequestDTO dto)
        {

            BaseResultDTO result = new BaseResultDTO();

            if(dto.Password==dto.newPassword)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "New Password cannot be same as old passwords.";

                return result;
            }
              

            if (dto.newPassword != dto.PassAgain)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Passwords must be same";

                return result;
            }
             

            bool CheckOldPassword = await _unitOfWork.ThingsRepository.CheckUserOldPassword(id, dto.newPassword);

            if (CheckOldPassword)
            {
                result.Status= RequestStatus.Failed;
                result.Message = "New Password cannot be same as old passwords.";

                return result;
            }
                

            bool CheckCurrent=  await _unitOfWork.ThingsRepository.CheckUserCurrentPassword(id, dto.Password);
            if (!CheckCurrent)
            {
                result.Status=RequestStatus.Failed;
                result.Message = "Enter Current Password";
            }
               
            
            await _unitOfWork.UserAuthRepository.ResetPasswordAsync(id, dto.newPassword);

            _unitOfWork.Commit();

            result.Status = RequestStatus.Success;
            result.Message = "You changed password succesfully!";

            return result;

         
        }

    }
}
