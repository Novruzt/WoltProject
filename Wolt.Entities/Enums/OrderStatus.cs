using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.Entities.Enums
{
    public enum OrderStatus
    {
        None=-1,
        Waiting= 1,
        Accepted,
        Failed,
        Returned,
    }
}
