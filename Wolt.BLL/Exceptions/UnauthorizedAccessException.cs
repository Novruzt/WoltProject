using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Exceptions
{
    public class UnauthorizedAccessException: Exception
    {
        public UnauthorizedAccessException():base()
        {
            
        }
        public UnauthorizedAccessException(string? message):base(message)
        {
            
        }
        public UnauthorizedAccessException(Exception exception):base(exception.Message + " " + exception.InnerException.Message) 
        {
            
        }
    }
}
