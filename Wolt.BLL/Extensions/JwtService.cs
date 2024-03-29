﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Configurations;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.Things
{
    public static class JwtService
    {
        private static readonly string Secret= JwtConfig.Secret;

        
        public static string CreateToken(User user)
        {


            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                }),

                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)

            };

            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);
            string JwtToken = jwtTokenHandler.WriteToken(token);


            return JwtToken;
        }
        public static int GetIdFromToken(string token)
        {

            byte[] key = Encoding.ASCII.GetBytes(Secret);
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(key);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey =true,
                IssuerSigningKey = signingKey,
                ValidateIssuer=false,
                ValidateAudience=false  
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                string idValue = principal.FindFirstValue("Id");

                if (int.TryParse(idValue, out int userId))
                {
                    return userId;
                }
                else
                {
                    return -1;
                }
                
            }

            catch 
            {
                return -1;
            }
        }
        public static bool ValidateToken(string token)
        {
            byte[] key = Encoding.ASCII.GetBytes(Secret);
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(key);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                string idValue = principal.FindFirstValue("Id");

                if (int.TryParse(idValue, out int userId))
                   if(userId >=0)
                    return true;

                return true;
            }
            catch (SecurityTokenException ex)
            {
                return false;
            }
        }
        public static string ForgotPasswordToken(User user)
        {


            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                }),

                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)

            };

            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);
            string JwtToken = jwtTokenHandler.WriteToken(token);

            return JwtToken;
        }
        public static string GetToken(IHeaderDictionary headers)
        {

            string token = headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            return token;

        }
    }
}
