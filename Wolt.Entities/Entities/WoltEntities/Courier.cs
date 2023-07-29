using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Enums;

namespace Wolt.Entities.Entities.WoltEntities
{
    public class Courier:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public CourierWorkStatus WorkStatus { get; set; }

        //Deliveries one to many
        
    }
}
