using MediatR;

namespace PhoneBook.Core.RequestBus
{
    public abstract class AppRequestHandler<TRequest> : AppInputHandler<TRequest>, IRequestHandler<TRequest, AppOutput> where TRequest : AppRequest
    {
        protected AppRequestHandler(IServiceProvider services) : base(services)
        {
        }

        public async Task<AppOutput> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }
    }
}
