using PhoneBook.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core
{
    /// <summary>
    /// აპლიკაციის პასუხი დაბრუნებული მნიშნველობის გარეშე
    /// </summary>
    public class AppOutput
    {
        public bool Success => StatusCode < 300;
        public int StatusCode { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }

        public static AppOutput Create(int statusCode)
        {
            return new AppOutput
            {
                StatusCode = statusCode
            };
        }

        public static AppOutput<TResult> Create<TResult>(int statusCode, TResult data)
        {
            return new AppOutput<TResult>
            {
                StatusCode = statusCode,
                Data = data
            };
        }

        public static AppOutput Create(int statusCode, string responseCode)
        {
            return new AppOutput
            {
                StatusCode = statusCode,
                ResponseCode = responseCode
            };
        }

        public static AppOutput<TResult> Create<TResult>(int statusCode, string responseCode, TResult data)
        {
            return new AppOutput<TResult>
            {
                StatusCode = statusCode,
                ResponseCode = responseCode,
                Data = data
            };
        }

        public static AppOutput Create(Exception ex)
        {
            if (ex is AppException appEx)
                return Create(appEx.StatusCode, appEx.ResponseCode);

            return Create(500, AppDefaultErrorCodes.InternalError);
        }
    }

    /// <summary>
    /// აპლიკაციის პასუხი დაბრუნებული მნიშვნელობით
    /// </summary>
    /// <typeparam name="TResult">დასაბრუნებელი მნიშნველობის ტიპი</typeparam>
    public class AppOutput<TResult> : AppOutput
    {
        public TResult Data { get; set; }
    }
}
