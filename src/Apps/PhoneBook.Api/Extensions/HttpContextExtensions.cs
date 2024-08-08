using PhoneBook.Api.Constants;
using PhoneBook.Core;

namespace PhoneBook.Api.Extensions
{
    public static class HttpContextExtensions
    {

        public static void StoreLanguageToItems(this HttpContext context)
        {
            var langStr = context.Request.Headers.AcceptLanguage;
            var langValue = Enum.TryParse(langStr, true, out AppLanguage lang) ? lang : AppLanguage.EN;
            context.Items.Add(HttpContextItemNames.Lang, langValue);
        }

        public static AppLanguage GetLanguageFromItems(this HttpContext context)
        {
            if (context.Items.TryGetValue(HttpContextItemNames.Lang, out object lang))
                return Enum.TryParse(lang?.ToString(), true, out AppLanguage langEnum) ? langEnum : AppLanguage.EN;

            return AppLanguage.EN;
        }

        public static void StoreRequestIdToItems(this HttpContext context)
        {
            var reqId = Guid.NewGuid().ToString();
            context.Items.Add(HttpContextItemNames.RequestId, reqId);
        }

        public static string GetRequestIdFromItems(this HttpContext context)
        {
            if (context.Items.TryGetValue(HttpContextItemNames.RequestId, out object reqId))
                return reqId.ToString();

            return null;
        }

        public static void StoreCorrelationIdToItems(this HttpContext context)
        {
            var corelationId = context.Request.Headers[HttpHeaderNames.CorrelationId].FirstOrDefault() ?? Guid.NewGuid().ToString();
            context.Items.Add(HttpContextItemNames.CorrelationId, corelationId);
        }

        public static string GetCorrelationIdFromItems(this HttpContext context)
        {
            if (context.Items.TryGetValue(HttpContextItemNames.RequestId, out object corId))
                return corId.ToString();

            return null;
        }

        public static int GetPageNumberFromQuery(this HttpContext context)
        {
            var val = context.Request.Query[QueryParameterNames.PageNumber].FirstOrDefault() ?? "1";
            return int.TryParse(val, out int pageNumber) ? pageNumber : 1;
        }

        public static int? GetRecordsOnPageFromQuery(this HttpContext context)
        {
            var val = context.Request.Query[QueryParameterNames.Records].FirstOrDefault();
            return int.TryParse(val, out int records) ? records : null;
        }
    }
}
