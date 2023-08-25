using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Exceptions
{
    public class NotFoundException :Exception
    {
        public NotFoundException() : base() 
        {
            
        }
        public NotFoundException(string? message):base(message)
        {
            
        }
        public NotFoundException(Exception exception):base(exception.Message + " " + exception.InnerException?.Message) 
        {
            
        }
    }
}
