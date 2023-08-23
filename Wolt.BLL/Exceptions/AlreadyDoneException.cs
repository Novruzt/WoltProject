using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Exceptions
{
    public class AlreadyDoneException :Exception
    {
        public AlreadyDoneException():base()
        {
            
        }
        public AlreadyDoneException(string? message):base(message)
        {
            
        }
        public AlreadyDoneException(Exception? exception):base(exception.Message+ " " +exception.InnerException.Message)
        {
            
        }
    }
}
