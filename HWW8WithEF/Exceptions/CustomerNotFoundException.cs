using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.Exceptions
{
    public class CustomerNotFoundException : VallidationException
    {
        public CustomerNotFoundException(string message) : base(message)
        {
        }
    }
}
