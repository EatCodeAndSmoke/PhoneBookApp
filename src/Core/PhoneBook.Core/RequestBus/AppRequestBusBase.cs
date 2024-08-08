using MediatR;

namespace PhoneBook.Core.RequestBus
{
    public class AppRequestBus : IAppRequestBus
    {
        private readonly IMediator _mediator;

        public AppRequestBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<AppOutput> SendAsync(AppRequest req)
        {
            var outPut = await _mediator.Send((object)req);
            return outPut as AppOutput;
        }
    }
}
