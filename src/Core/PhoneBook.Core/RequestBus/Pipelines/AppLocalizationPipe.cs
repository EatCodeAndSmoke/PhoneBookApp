using MediatR;
using PhoneBook.Core.Exceptions;

namespace PhoneBook.Core.RequestBus.Pipelines
{
    public class AppLocalizationPipe<TRequest, TResponse> : AppOutputProducer, IPipelineBehavior<TRequest, TResponse>
        where TRequest : AppRequest
        where TResponse : AppOutput
    {
        public AppLocalizationPipe(IServiceProvider services) : base(services)
        {
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var resp = await next();

            if (!string.IsNullOrWhiteSpace(resp.ResponseCode))
                resp.Message = await Translator.TranslateAsync(resp.ResponseCode, request.Lang);

            if (resp is AppOutput<IEnumerable<AppErrorDescriptor>> validationErrorResp)
            {
                if (validationErrorResp.Data is not null)
                {
                    foreach (var item in validationErrorResp.Data)
                    {
                        if (!string.IsNullOrWhiteSpace(item.ErrorCode))
                            item.Message = await Translator.TranslateAsync(item.ErrorCode, request.Lang);
                    }
                }
            }

            return resp;
        }
    }
}
