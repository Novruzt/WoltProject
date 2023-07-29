using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class UserReturn:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }  
        public string Description { get; set; }
        public DateTime ReturnTime { get; set; } 
        public ICollection<Order> Order { get; set; }    

        //Order and OrderId
    }
}
