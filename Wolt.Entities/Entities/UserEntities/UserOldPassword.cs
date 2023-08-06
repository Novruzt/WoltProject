using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class UserOldPassword:BaseEntity
    {
        public string OldPassword { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
