using PhoneBook.Application.Common.Models;
using PhoneBook.Application.Domain.Person;
using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Application.Domain.PhoneNumber.Constants;
using PhoneBook.Core;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.PhoneNumber.Requests.Create
{
    public class AddPhoneNumberReqHandler : AppRequestHandler<AddPhoneNumberReq>
    {
        private readonly IPersonRepository _personRepo;
        private readonly IPhoneNumberRepository _phoneRepo;

        public AddPhoneNumberReqHandler(IServiceProvider services, IPersonRepository personRepo, IPhoneNumberRepository phoneRepo) : base(services)
        {
            _personRepo = personRepo;
            _phoneRepo = phoneRepo;
        }

        public override async ValueTask<AppOutput> HandleAsync(AddPhoneNumberReq input, CancellationToken cancellationToken)
        {
            var person = await _personRepo.GetByIdAsync(input.Body.PersonId);
            if (person == null)
                return BadRequest(PersonErrorCodes.NotFound);

            var numberExists = await _phoneRepo.PhoneNumberExistsAsync(input.Body.PersonId, new PhoneModel(input.Body.PhoneNumber, input.Body.NumberType));
            if(numberExists)
                return BadRequest(PNErrorCodes.AlreadyExists);

            var entity = new PhoneNumberEntity
            {
                CorrelationId = input.CorrelationId,
                CreatedAt = DateTimeOffset.UtcNow,
                Number = input.Body.PhoneNumber,
                NumberType = input.Body.NumberType,
                PersonId = input.Body.PersonId
            };

            await UnitOfWork.AddAsync(entity, cancellationToken);
            return Ok();
        }
    }
}
