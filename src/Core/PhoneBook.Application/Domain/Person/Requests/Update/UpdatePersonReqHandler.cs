using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Core;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.Person.Requests.Update
{
    public class UpdatePersonReqHandler : AppRequestHandler<UpdatePersonReq>
    {
        private readonly IPersonRepository _personRepo;

        public UpdatePersonReqHandler(IServiceProvider services, IPersonRepository personRepo) : base(services)
        {
            _personRepo = personRepo;
        }

        public override async ValueTask<AppOutput> HandleAsync(UpdatePersonReq input, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var person = await _personRepo.GetByIdAsync(input.Body.Id);
            if (person == null)
                return BadRequest(PersonErrorCodes.NotFound);

            person.FirstName = input.Body.FirstName;
            person.LastName = input.Body.LastName;  
            person.Gender = input.Body.Gender;
            person.PersonalNumber = input.Body.PersonalNumber;
            person.CityId = input.Body.CityId;
            person.UpdatedAt = DateTimeOffset.UtcNow;

            await UnitOfWork.UpdateAsync(person, cancellationToken);
            return Ok();
        }
    }
}
