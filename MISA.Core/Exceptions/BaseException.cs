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
    public class BaseException : Exception
    {
        // ctrosc
        public BaseException(string msg) : base(msg)
        {

        }

    }
}
