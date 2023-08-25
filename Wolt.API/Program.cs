using Microsoft.EntityFrameworkCore;
using Wolt.Entities.Entities.RestaurantEntities;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository;
using WOLT.DAL.UnitOfWork.Abstract;
using WOLT.DAL.UnitOfWork.Concrete;
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
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using FluentValidation.AspNetCore;
using FluentValidation;
using Wolt.BLL.DTOs.UserProfileDTOs;
using Wolt.BLL.Registrations;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Wolt.BLL.Things;
using Wolt.BLL.Extensions;
using Serilog;
using DocumentFormat.OpenXml.InkML;
using Serilog.Context;
using System.Security.Claims;

namespace Wolt.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.RegisterValidators();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                      {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                      }
                      },
                      new string[] { }
                    }
                });

                opt.EnableAnnotations();
            });

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

            builder.Services.AddScoped<CustomAuthAttribute>();

            builder.Services.ConfigureRepository();
            builder.Services.ConfigureServices();

            builder.Services.AddDbContext<DataContext>(options =>
            {

             options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            

            });

            Log.Logger=new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                 .Enrich.With<UserEnricher>()
                .CreateLogger();

            builder.Host.UseSerilog();

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

   
            app.UseSerilogRequestLogging();

            app.Use(async (context, next) =>
            {
             //   var userId = context.User.FindFirstValue(ClaimTypes.);
                var userEmail = context.User.FindFirstValue(ClaimTypes.Email);

             //   LogContext.PushProperty("UserId", userId);
                LogContext.PushProperty("UserEmail", userEmail);

                await next();
            });
            app.MapControllers();

            app.AddGlobalErrorHandler();

          //  app.UseMiddleware<ApiCustomLoggingMiddleware>();

            app.Run();

        }
    }
}