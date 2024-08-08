using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Exceptions;

namespace PhoneBook.Core.RequestBus.Pipelines
{
    public class AppValidationPipe<TRequest, TResponse> : AppOutputProducer, IPipelineBehavior<TRequest, TResponse> 
        where TRequest : AppRequest
        where TResponse : AppOutput
    {
        public AppValidationPipe(IServiceProvider services) : base(services)
        {
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (Services.GetService<IValidator<TRequest>>() is IValidator<TRequest> validator)
            {
                var valResult = validator.Validate(request);
                if (!valResult.IsValid)
                {
                    var appErrors = valResult.Errors.Select(x => AppErrorDescriptor.Create(x));
                    return BadRequest(appErrors) as TResponse;
                }
            }

            return await next();
        }
    }
}
