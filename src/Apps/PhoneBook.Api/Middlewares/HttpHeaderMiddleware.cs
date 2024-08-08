using PhoneBook.Api.Constants;
using PhoneBook.Api.Extensions;
using PhoneBook.Core;

namespace PhoneBook.Api.Middlewares
{
    public class HttpHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.StoreLanguageToItems();
            context.StoreRequestIdToItems();
            context.StoreCorrelationIdToItems();

            await _next(context);
        }
    }
}
