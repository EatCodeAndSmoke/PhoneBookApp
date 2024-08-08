using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Constants;
using PhoneBook.Api.DTO;
using PhoneBook.Api.Extensions;
using PhoneBook.Core;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly Lazy<IAppRequestBus> _lazyRequestBus;

        public BaseController()
        {
            _lazyRequestBus = new Lazy<IAppRequestBus>(() => HttpContext.RequestServices.GetRequiredService<IAppRequestBus>());
        }

        protected IAppRequestBus RequestBus => _lazyRequestBus.Value;

        protected async Task<IActionResult> ExecuteAsync(AppRequest request)
        {
            PopulateRequest(request);
            var resp = await RequestBus.SendAsync(request);

            if (resp.Success)
            {
                HttpContext.Response.Headers.Append(HttpHeaderNames.ResponseCode, resp.ResponseCode);
                return StatusCode(resp.StatusCode);
            }
            else
            {
                var dto = ErrorDto.FromAppOutput(resp);
                return StatusCode(resp.StatusCode, dto);
            }
        }

        protected async Task<IActionResult> ExecuteAsync<TResp>(AppRequest request)
        {
            PopulateRequest(request);
            var resp = await RequestBus.SendAsync(request);

            if (resp.Success)
            {
                HttpContext.Response.Headers.Append(HttpHeaderNames.ResponseCode, resp.ResponseCode);

                if (resp is AppOutput<TResp> appResp)
                    return StatusCode(resp.StatusCode, appResp.Data);

                return StatusCode(resp.StatusCode);
            }
            else
            {
                var dto = ErrorDto.FromAppOutput(resp);
                return StatusCode(resp.StatusCode, dto);
            }
        }

        private void PopulateRequest(AppRequest request)
        {
            request.Id = HttpContext.GetRequestIdFromItems();
            request.CorrelationId = HttpContext.GetCorrelationIdFromItems();
            request.Lang = HttpContext.GetLanguageFromItems();

            if (request is IAppPageRequest pageReq)
            {
                pageReq.PageNumber = HttpContext.GetPageNumberFromQuery();
                pageReq.RecordsOnPage = HttpContext.GetRecordsOnPageFromQuery();
            }
        }
    }
}
