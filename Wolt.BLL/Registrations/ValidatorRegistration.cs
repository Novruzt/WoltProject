using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Registrations
{
    public static class ValidatorRegistation
    {
        public static void RegisterValidators(this IServiceCollection services)
        {

            var abstractValidatorType = typeof(AbstractValidator<>);

            var assembly = Assembly.GetExecutingAssembly();

            var validatorTypes = assembly.GetTypes()
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == abstractValidatorType);

            foreach (var validatorType in validatorTypes)
            {
                
                var genericArgument = validatorType.BaseType.GetGenericArguments()[0];


                services.AddValidatorsFromAssemblyContaining(genericArgument);
            }
        }
    }
}
