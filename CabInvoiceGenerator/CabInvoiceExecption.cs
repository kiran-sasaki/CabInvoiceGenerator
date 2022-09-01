using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceExecption : Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            INVALID_RIDES,
            INVALID_USER_ID
        }

        ExceptionType type;

        public CabInvoiceExecption(ExceptionType type,string message):base(message)
        {
            this.type = type;
        }
    }
}
