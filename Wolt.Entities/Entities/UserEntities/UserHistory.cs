using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class UserHistory:BaseEntity
    {
        public UserHistory()
        {
            Orders= new List<Order>();
        }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
