using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Extensions
{

    public class UserEnricher : ILogEventEnricher
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserEnricher(): this(new HttpContextAccessor())
        {
            
        }

        public UserEnricher(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
            "UserId", _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "NotUser"));

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
            "UserEmail", _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email) ?? "anonymous"));


        }
    }
}

