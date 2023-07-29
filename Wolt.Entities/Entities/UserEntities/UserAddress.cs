using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class UserAddress:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
    }
}
