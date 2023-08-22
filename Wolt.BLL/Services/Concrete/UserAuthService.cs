using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
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
using WOLT.DAL.Repository.Concrete;
using WOLT.DAL.UnitOfWork.Abstract;

namespace Wolt.BLL.Services.Concrete
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserAuthService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetUserProfileDTO> GetUserAsync(string token)
        {

            int UserId = JwtService.GetIdFromToken(token);

            User user = await _unitOfWork.UserAuthRepository.GetAsync(UserId);
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

            User user = await _unitOfWork.UserAuthRepository.GetByEmailAsync(dto.Email);

            LoginUserResponseDTO response = new LoginUserResponseDTO();

            bool isUser = UserPasswordService.VerifyPassword(dto.Password, user.PasswordSalt, user.PasswordHash);
            if (isUser)
            {

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

            string[] passwordTogether = UserPasswordService.CalculateSha256Hash(newUser.Password);

            user.PasswordHash = passwordTogether[0];
            user.PasswordSalt = passwordTogether[1];

            await _unitOfWork.UserAuthRepository.RegisterUserAsync(user);
            _unitOfWork.Commit();

            RegisterUserResponseDTO response = new RegisterUserResponseDTO()
            {

                Token = JwtService.CreateToken(user),
                Result = true

            };

            user.Token = response.Token;

            UserOldPassword oldPassword = new UserOldPassword()
            {
                OldPasswordHash = user.PasswordHash,
                OldPasswordSalt = user.PasswordSalt,
                UserId = user.Id
            };

            await _unitOfWork.UserInteractRepository.CreateUserHistoryAsync(user.Id);
            await _unitOfWork.UserAuthRepository.AddOldPasswordAsync(oldPassword);

            _unitOfWork.Commit();

            return response;
        }

        public async Task<BaseResultDTO> ResetPasswordAsync(int id, ResetPasswordRequestDTO dto)
        {

            BaseResultDTO result = new BaseResultDTO();

            User user = await _unitOfWork.UserAuthRepository.GetAsync(id);

            if (user == null)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "No user found!";

                return result;
            }

            bool CheckCurrent = UserPasswordService.VerifyPassword(dto.Password, user.PasswordSalt, user.PasswordHash);
            if (!CheckCurrent)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Enter Current Password";

                return result;
            }

            if (dto.Password == dto.newPassword)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "New Password cannot be same as current password.";

                return result;
            }


            if (dto.newPassword != dto.PassAgain)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Passwords must be same";

                return result;
            }

            string[] passwordTogether = UserPasswordService.CalculateSha256Hash(dto.newPassword);

            string newPasswordHash = passwordTogether[0];
            string newPasswordSalt = passwordTogether[1];

            List<UserOldPassword> userOldPasswords = await _unitOfWork.UserAuthRepository.GetAllUserOldPasswordsAsync(id);

            bool CheckOldPassword = UserPasswordService.CheckOldPassword(dto.newPassword, userOldPasswords);

            if (CheckOldPassword)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "New Password cannot be same as old passwords.";

                return result;
            }

            await _unitOfWork.UserAuthRepository.ResetPasswordAsync(id, newPasswordHash, newPasswordSalt);

            UserOldPassword oldPassword = new UserOldPassword()
            {
                UserId=user.Id,
                OldPasswordHash=newPasswordHash,
                OldPasswordSalt=newPasswordSalt,
            };

            await _unitOfWork.UserAuthRepository.AddOldPasswordAsync(oldPassword);

            _unitOfWork.Commit();

            result.Status = RequestStatus.Success;
            result.Message = "You changed password succesfully!";

            return result;


        }

        public async Task<BaseResultDTO> ChangeProfilePictureAsync(string token, string? picture)
        {
            BaseResultDTO result = new BaseResultDTO();

            bool IsToken = JwtService.ValidateToken(token);

            if (!IsToken)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid Token!";

                return result;

            }

            int userId = JwtService.GetIdFromToken(token);

            if (userId <= 0)
            {
                result.Status = RequestStatus.Failed;
                result.Message = "Invalid user id";

                return result;
            }


            try
            {
                await _unitOfWork.UserAuthRepository.ChangeProfilePictureAsync(userId, picture);
                _unitOfWork.Commit();

                result.Status = RequestStatus.Success;
                result.Message = "Change applied succesfully.";

                return result;
            }
            catch (Exception ex)
            {
                result.Status = RequestStatus.Failed;
                result.Message = ex.Message;

                return result;
            }


        }
    }
}
