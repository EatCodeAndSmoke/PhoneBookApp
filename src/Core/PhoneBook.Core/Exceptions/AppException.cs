using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Exceptions
{
    public class AppException : Exception
    {
        public AppException(int statusCode, string responseCode = null, IEnumerable<AppErrorDescriptor> errors = null)
        {
            StatusCode = statusCode;
            ResponseCode = responseCode;
            ValidationErrors = errors;
        }

        public int StatusCode { get; set; }
        public string ResponseCode { get; set; }
        public IEnumerable<AppErrorDescriptor> ValidationErrors { get; set; }

        public static void ThrowBadRequest(string responseCode = null)
        {
            var statusCode = (int)HttpStatusCode.BadRequest;
            responseCode = ResponseCodeOrDefault(statusCode, responseCode);
            throw new AppException(statusCode, responseCode);
        }

        public static void ThrowUnautorized(string responseCode = null)
        {
            var statusCode = (int)HttpStatusCode.Unauthorized;
            responseCode = ResponseCodeOrDefault(statusCode, responseCode);
            throw new AppException(statusCode, responseCode);
        }

        public static void ThrowForbidden(string responseCode = null)
        {
            var statusCode = (int)HttpStatusCode.Forbidden;
            responseCode = ResponseCodeOrDefault(statusCode, responseCode);
            throw new AppException(statusCode, responseCode);
        }

        public static void ThrowInternal(string responseCode = null)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            responseCode = ResponseCodeOrDefault(statusCode, responseCode);
            throw new AppException(statusCode, responseCode);
        }

        public static string ResponseCodeOrDefault(int statusCode, string responseCode)
        {
            if (!string.IsNullOrWhiteSpace(responseCode))
                return responseCode;

            return statusCode switch
            {
                (int)HttpStatusCode.BadRequest => AppDefaultErrorCodes.BadRequest,
                (int)HttpStatusCode.Unauthorized => AppDefaultErrorCodes.Unauthorized,
                (int)HttpStatusCode.Forbidden => AppDefaultErrorCodes.Forbidden,
                _ => AppDefaultErrorCodes.InternalError
            };
        }
    }
}
