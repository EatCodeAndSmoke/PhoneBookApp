using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Exceptions
{
    public class AppErrorDescriptor
    {
        public string PropertyName { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }

        public static AppErrorDescriptor Create(ValidationFailure fluentError)
        {
            return new AppErrorDescriptor
            {
                ErrorCode = fluentError.ErrorCode,
                PropertyName = fluentError.PropertyName,
            };
        }
    }
}
