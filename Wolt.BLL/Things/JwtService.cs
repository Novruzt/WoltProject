using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Configurations;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.Things
{
    public static class JwtService
    {
        private static readonly string Secret= "YMaImDZxzEEPnPjOwcWmiCRpkkHHljBR";

        
        public static string CreateToken(User user)
        {


            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
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
                int userId = int.Parse(principal.FindFirstValue("Id"));

                return userId;
            }

            catch (SecurityTokenException ex) 
            {
                return -1;
            }

           

        }


    }
}
