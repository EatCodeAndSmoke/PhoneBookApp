using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.DAL;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Core
{
    public abstract class AppInputHandler<TInput> : AppOutputProducer where TInput : class, IAppInput
    {
        protected AppInputHandler(IServiceProvider services) : base(services)
        {
        }

        public abstract ValueTask<AppOutput> HandleAsync(TInput input, CancellationToken cancellationToken);
    }
}
