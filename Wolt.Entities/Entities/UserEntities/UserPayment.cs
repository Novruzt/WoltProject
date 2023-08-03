using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class UserPayment:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string CardNumber { get; set; }
        public string CCV { get; set; }
        public string ExpireTime { get; set; }


    }
}
