using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.Exceptions
{
    public class CustomerAlreadyExistException : VallidationException
    {
        public CustomerAlreadyExistException(string message) : base(message)
        {
        }
    }
}
