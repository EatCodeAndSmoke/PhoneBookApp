using PhoneBook.Application.Domain.Person;
using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Application.Domain.PersonRelation.Constants;
using PhoneBook.Core;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.PersonRelation.Requests.Create
{
    public class AddPersonRelationReqHandler : AppRequestHandler<AddPersonRelationReq>
    {
        private readonly IPersonRepository _personRepo;
        private readonly IPersonRelationRepository _relationRepo;

        public AddPersonRelationReqHandler(IServiceProvider services, IPersonRepository personRepo, IPersonRelationRepository relationRepo) : base(services)
        {
            _personRepo = personRepo;
            _relationRepo = relationRepo;
        }

        public override async ValueTask<AppOutput> HandleAsync(AddPersonRelationReq input, CancellationToken cancellationToken)
        {
            if(!await _personRepo.ExistsByIdAsync(input.Body.PrimaryPersonId))
                return BadRequest(PersonErrorCodes.NotFound);

            if (!await _personRepo.ExistsByIdAsync(input.Body.SecondaryPersonId))
                return BadRequest(PersonErrorCodes.NotFound);

            var relationExists = await _relationRepo.RelationExistsAsync(input.Body.PrimaryPersonId, input.Body.SecondaryPersonId, input.Body.RelationType);
            if(relationExists)
                return BadRequest(PRErrorCodes.AlreadyExists);

            var entity = new PersonRelationEntity
            {
                CorrelationId = input.CorrelationId,
                CreatedAt = DateTimeOffset.UtcNow,
                PrimaryPersonId = input.Body.PrimaryPersonId,
                SecondaryPersonId = input.Body.SecondaryPersonId,
                RelationType = input.Body.RelationType,
            };

            await UnitOfWork.AddAsync(entity, cancellationToken);
            return Ok();
        }
    }
}
