using PhoneBook.Application.Domain.PersonRelation.Constants;
using PhoneBook.Core;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.PersonRelation.Requests.Remove
{
    public class RemovePersonRelationReqHandler : AppRequestHandler<RemovePersonRelationReq>
    {
        private readonly IPersonRelationRepository _personRelationRepo;

        public RemovePersonRelationReqHandler(IServiceProvider services, IPersonRelationRepository personRelationRepo) : base(services)
        {
            _personRelationRepo = personRelationRepo;
        }

        public override async ValueTask<AppOutput> HandleAsync(RemovePersonRelationReq input, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var entity = await _personRelationRepo.GetByIdAsync(input.Body.Id);
            if(entity == null)
                return BadRequest(PRErrorCodes.NotFound);

            await UnitOfWork.RemoveAsync(entity, cancellationToken);
            return Ok();
        }
    }
}
