using PhoneBook.Application.Domain.City;
using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Application.Domain.PersonRelation;
using PhoneBook.Application.Domain.PhoneNumber;
using PhoneBook.Core;
using PhoneBook.Core.Extensions;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.Person.Requests.GetById
{
    public class GetPersonByIdReqHandler : AppRequestHandler<GetPersonByIdReq>
    {
        private readonly IPersonRepository _personRepo;
        private readonly IPersonRelationRepository _personRelationRepo;
        private readonly IPhoneNumberRepository _phoneNumberRepo;
        private readonly ICityRepository _cityRepo;

        public GetPersonByIdReqHandler(
            IServiceProvider services,
            IPersonRepository personRepo,
            IPersonRelationRepository personRelationRepo,
            IPhoneNumberRepository phoneNumberRepo,
            ICityRepository cityRepo) : base(services)
        {
            _personRepo = personRepo;
            _personRelationRepo = personRelationRepo;
            _phoneNumberRepo = phoneNumberRepo;
            _cityRepo = cityRepo;
        }

        public override async ValueTask<AppOutput> HandleAsync(GetPersonByIdReq input, CancellationToken cancellationToken)
        {
            var person = await _personRepo.GetByIdAsync(input.Body.Id);
            if (person == null)
                return BadRequest(PersonErrorCodes.NotFound);

            var relations = await GetRelationsAsync(input);
            var phoneNumbers = await GetPhoneNumbersAsync(input);
            var city = await _cityRepo.GetByIdAsync(person.CityId);

            var resp = new GetPersonByIdResp
            {
                Id = person.Id,
                CityId = person.CityId,
                CreatedAt = person.CreatedAt,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                PersonalNumber = person.PersonalNumber,
                PhotoUrl = person.PhotoUrl,
                PhoneNumbers = phoneNumbers,
                Relations = relations,
                CityName = input.Lang == AppLanguage.GE ? city?.NameGe : city?.NameEng
            };

            return Ok(resp);
        }

        private async Task<List<GetPersonByIdResp.PersonRelationData>> GetRelationsAsync(GetPersonByIdReq input)
        {
            return await (from pr in _personRelationRepo.QueryAllByPerson(input.Body.Id)
                          join p in _personRepo.QueryAll()
                          on pr.SecondaryPersonId equals p.Id
                          select new GetPersonByIdResp.PersonRelationData
                          {
                              Id = pr.Id,
                              PersonId = p.Id,
                              PersonName = $"{p.FirstName} {p.LastName}",
                              RelationType = pr.RelationType
                          }).ToListAsync();
        }

        private async Task<List<GetPersonByIdResp.PhoneNumberData>> GetPhoneNumbersAsync(GetPersonByIdReq input)
        {
            return await (_phoneNumberRepo.QueryAllByPerson(input.Body.Id)
                                          .Select(x => new GetPersonByIdResp.PhoneNumberData
                                          {
                                              Id = x.Id,
                                              Number = x.Number,
                                              NumberType = x.NumberType
                                          })).ToListAsync();
        }

    }
}
