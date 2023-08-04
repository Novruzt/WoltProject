using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOLT.DAL.Repository.Abstract;
using WOLT.DAL.Repository.Concrete;

namespace WOLT.DAL.Repository
{
    public static  class ServiceRegistration
    {

        public static void ConfigureRepository(this IServiceCollection services)
        {

            services.Scan(scan =>
            {
                scan.FromAssembliesOf(typeof(UserProfileRepository))
                .AddClasses()
                .AsMatchingInterface()
                .WithScopedLifetime();
            });
        }

    }
}
