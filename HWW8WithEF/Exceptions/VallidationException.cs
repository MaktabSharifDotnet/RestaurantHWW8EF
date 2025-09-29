using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.Exceptions
{
    public class VallidationException : Exception
    {
        public VallidationException(string message):base(message) 
        {
            
        }
    }
}
