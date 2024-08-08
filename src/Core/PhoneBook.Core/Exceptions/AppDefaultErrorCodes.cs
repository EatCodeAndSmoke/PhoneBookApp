using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Exceptions
{
    public static class AppDefaultErrorCodes
    {
        public const string BadRequest = "ER.DF.BAD_REQUEST";
        public const string Unauthorized = "ER.DF.UNAUTH";
        public const string Forbidden = "ER.DF.FORBIDDEN";
        public const string InternalError = "ER.DF.INTERNAL_ERROR";
    }
}
