using PhoneBook.Api.DTO;
using PhoneBook.Api.Extensions;
using PhoneBook.Core;
using PhoneBook.Core.Exceptions;

namespace PhoneBook.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error occured");

                var lang = context.GetLanguageFromItems();
                var msg = lang == AppLanguage.EN ? "Error occured" : "დაფიქსირდა შეცდომა";
                var dto = new ErrorDto(AppDefaultErrorCodes.InternalError, msg, null);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(dto);
            }
        }
    }
}
