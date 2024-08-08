using MediatR;
using Microsoft.Extensions.Logging;

namespace PhoneBook.Core.RequestBus.Pipelines
{
    public class AppErrorHandlerPipe<TRequest, TResponse> : AppOutputProducer, IPipelineBehavior<TRequest, TResponse>
        where TRequest : AppRequest
        where TResponse : AppOutput
    {
        private readonly ILogger<AppErrorHandlerPipe<TRequest, TResponse>> _logger;

        public AppErrorHandlerPipe(IServiceProvider services, ILogger<AppErrorHandlerPipe<TRequest, TResponse>> logger) : base(services)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error occured: ");
                return FromException(ex) as TResponse;
            }
        }
    }
}
