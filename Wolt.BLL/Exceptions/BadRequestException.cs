using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Exceptions
{
    public class BadRequestException: Exception
    {
        public BadRequestException(): base()
        {
             
        }
        public BadRequestException(string? message): base(message)
        {
                
        }
        public BadRequestException(Exception? exception):base(exception.Message + " " + exception.InnerException.Message) 
        {
            
        }
    }
}
