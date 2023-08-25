using Microsoft.AspNetCore.Http;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Extensions;

namespace Wolt.BLL.Configurations
{
    public class UserEnricherFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserEnricherFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ILogEventEnricher CreateEnricher()
        {
            return new UserEnricher(_httpContextAccessor);
        }
    }
}
