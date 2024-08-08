using PhoneBook.Application.Domain.PhoneNumber.Constants;
using PhoneBook.Core;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.PhoneNumber.Requests.Remove
{
    public class RemovePhoneNumberReqHandler : AppRequestHandler<RemovePhoneNumberReq>
    {
        private readonly IPhoneNumberRepository _phoneRepo;

        public RemovePhoneNumberReqHandler(IServiceProvider services, IPhoneNumberRepository phoneRepo) : base(services)
        {
            _phoneRepo = phoneRepo;
        }

        public override async ValueTask<AppOutput> HandleAsync(RemovePhoneNumberReq input, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var entity = await _phoneRepo.GetByIdAsync(input.Body.Id);
            if (entity == null)
                return BadRequest(PNErrorCodes.NotFound);

            await UnitOfWork.RemoveAsync(entity, cancellationToken);
            return Ok();
        }
    }
}
