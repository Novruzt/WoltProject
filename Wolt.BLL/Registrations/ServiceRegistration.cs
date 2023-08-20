using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.AutoMappers;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Services.Concrete;
using AutoMapper;
using WOLT.DAL.Repository.Concrete;

namespace Wolt.BLL.Registrations
{
    public static class ServiceRegistration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.Scan(scan =>
            {
                scan.FromAssembliesOf(typeof(UserProfileService))
                .AddClasses()
                .AsMatchingInterface()
                .WithScopedLifetime();
            });
        }
    }
}
