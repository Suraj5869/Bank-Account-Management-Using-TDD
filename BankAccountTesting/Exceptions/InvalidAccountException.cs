using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTesting.Exceptions
{
    internal class InvalidAccountException:Exception
    {
        public InvalidAccountException(string msg):base(msg)
        {
            
        }
    }
}
