
using Microsoft.EntityFrameworkCore;
using Wolt.Entities.Entities.RestaurantEntities;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository;
using WOLT.DAL.UnitOfWork.Abstract;
using WOLT.DAL.UnitOfWork.Concrete;
using Wolt.BLL.Services;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Services.Concrete;
using Microsoft.AspNetCore.Cors.Infrastructure;
using WOLT.DAL.Repository.Concrete;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Wolt.BLL.Configurations;

namespace Wolt.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c=>c.EnableAnnotations());

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(key: "JwtConfig"));

         
            builder.Services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;

            }
            ).AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey=  new SymmetricSecurityKey(key),
                    ValidateIssuer=false,
                    ValidateAudience=false,
                    RequireExpirationTime=false,
                    ValidateLifetime=false,

                };
            });

            builder.Services.ConfigureRepository();
            builder.Services.ConfigureServices();

            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}