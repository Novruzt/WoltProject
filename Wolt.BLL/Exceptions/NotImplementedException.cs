using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Exceptions
{
    public class NotImplementedException: Exception
    {
        public NotImplementedException() : base() 
        {   

        }
        public NotImplementedException(string? message): base(message) 
        {

        }    

        public NotImplementedException(Exception exception):base(exception.Message + " " + exception.InnerException?.Message)
        {
            
        }
    }
}
