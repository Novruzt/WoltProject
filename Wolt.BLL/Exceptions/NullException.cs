using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Exceptions
{
    public class NullException: Exception
    {
        public NullException():base()
        {
            
        }
        public NullException(string? message):base(message)
        {
            
        }
        public NullException(Exception exception):base(exception.Message + " " + exception.InnerException.Message)
        {
            
        }
    }
}
