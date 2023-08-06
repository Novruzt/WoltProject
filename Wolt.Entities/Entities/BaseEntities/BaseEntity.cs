using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.Entities.Entities.BaseEntities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }    
        public DateTime? DeleteTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}
