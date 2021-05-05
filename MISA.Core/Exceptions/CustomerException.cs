using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Exceptions
{
    /// <summary>
    /// Customer Exception
    /// </summary>
    /// CreatedBy: KDLong 28/04/2021
    public class CustomerException : Exception
    {
        // ctrosc
        public CustomerException(string msg) : base(msg)
        {

        }
        public CustomerException(string msg, string customerCode) : base(msg)
        {

        }

    }
}
