
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

namespace Wolt.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}