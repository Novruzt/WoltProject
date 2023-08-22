using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Wolt.BLL.Things
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class CustomAuthAttribute : ActionFilterAttribute
    {

        public CustomAuthAttribute()
        {
            
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            IThingsService thingsService = context.HttpContext.RequestServices.GetRequiredService<IThingsService>();

            string token = JwtService.GetToken(context.HttpContext.Request.Headers);

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult("Token not provided");
                return;
            }

            bool checker = await thingsService.CheckUserByToken(token);

            if (!checker)
            {
                context.Result = new BadRequestObjectResult("No user found");
                return; 
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}
