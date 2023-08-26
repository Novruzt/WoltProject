using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;

namespace Wolt.Entities.Entities.WoltEntities
{
    public class WoltLog:BaseEntity
    {
        public int? userId { get; set; }
        public string? userEmail { get; set; }
        public int StatusCode { get; set; }
        [MaxLength(200)]
        public string ApiUrl { get; set; }
    }
}
