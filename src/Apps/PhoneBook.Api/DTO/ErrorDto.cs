using PhoneBook.Core;
using PhoneBook.Core.Exceptions;

namespace PhoneBook.Api.DTO
{
    public record ErrorDto
    {
        public ErrorDto(string responseCode, string message, object data)
        {
            ResponseCode = responseCode;
            Message = message;
        }

        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static ErrorDto FromAppOutput(AppOutput output)
        {
            if (output.Success)
                return null;

            if (output is AppOutput<IEnumerable<AppErrorDescriptor>> invalidResp)
                return new ErrorDto(output.ResponseCode, output.Message, invalidResp.Data);

            return new ErrorDto(output.ResponseCode, output.Message, null);
        }
    }
}
