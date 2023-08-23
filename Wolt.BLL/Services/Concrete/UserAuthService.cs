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
using Wolt.BLL.Exceptions;
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
        public UserAuthService(IMapper mapper, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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

            try
            {
                if (newUser.ProfilePic != null)
                {

                    if (!FileService.IsImage(newUser.ProfilePic))
                        throw new BadRequestException("Upload valid image.");

                    string currPath = _webHostEnvironment.ContentRootPath;
                    string fullPath = FileService.SaveImage(newUser.ProfilePic, _webHostEnvironment);

                    newUser.ProfilePicture = fullPath;
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }


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

        public async Task ResetPasswordAsync(int id, ResetPasswordRequestDTO dto)
        {

            User user = await _unitOfWork.UserAuthRepository.GetAsync(id);

            bool CheckCurrent = UserPasswordService.VerifyPassword(dto.Password, user.PasswordSalt, user.PasswordHash);
            if (!CheckCurrent)
                throw new BadRequestException("Enter current password.");

            if (dto.Password == dto.newPassword)
                throw new BadRequestException("New Password cannot be same as current password.");


            if (dto.newPassword != dto.PassAgain)
                throw new BadRequestException("Passwords must be same");

            string[] passwordTogether = UserPasswordService.CalculateSha256Hash(dto.newPassword);

            string newPasswordHash = passwordTogether[0];
            string newPasswordSalt = passwordTogether[1];

            List<UserOldPassword> userOldPasswords = await _unitOfWork.UserAuthRepository.GetAllUserOldPasswordsAsync(id);

            bool CheckOldPassword = UserPasswordService.CheckOldPassword(dto.newPassword, userOldPasswords);

            if (CheckOldPassword)
                throw new BadRequestException("New Password cannot be same as old passwords.");

            await _unitOfWork.UserAuthRepository.ResetPasswordAsync(id, newPasswordHash, newPasswordSalt);

            UserOldPassword oldPassword = new UserOldPassword()
            {
                UserId = user.Id,
                OldPasswordHash = newPasswordHash,
                OldPasswordSalt = newPasswordSalt,
            };

            await _unitOfWork.UserAuthRepository.AddOldPasswordAsync(oldPassword);

            _unitOfWork.Commit();

        }

        public async Task ChangeProfilePictureAsync(string token, ChangeProfilePictureDTO dto)
        {

            int userId = JwtService.GetIdFromToken(token);
            User user = await _unitOfWork.UserAuthRepository.GetAsync(userId);

            string fullPath = null;
            string oldPath = user.ProfilePicture;

            try
            {
                if (dto.ProfilePic != null)
                {

                    if (!FileService.IsImage(dto.ProfilePic))
                        throw new BadRequestException("Upload valid image.");

                    string currPath = _webHostEnvironment.ContentRootPath;
                    fullPath = FileService.SaveImage(dto.ProfilePic, _webHostEnvironment);

                    if (oldPath != null)
                        FileService.DeleteImage(oldPath, _webHostEnvironment);

                    
                        await _unitOfWork.UserAuthRepository.ChangeProfilePictureAsync(userId, fullPath);
                        _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex);
            }
        }

    }
}


