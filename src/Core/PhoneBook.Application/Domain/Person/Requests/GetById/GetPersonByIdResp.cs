using PhoneBook.Application.Domain.PersonRelation;
using PhoneBook.Application.Domain.PhoneNumber;

namespace PhoneBook.Application.Domain.Person.Requests.GetById
{
    public record GetPersonByIdResp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonGender Gender { get; set; }
        public string PersonalNumber { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PhotoUrl { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public IEnumerable<PhoneNumberData> PhoneNumbers { get; set; }
        public IEnumerable<PersonRelationData> Relations { get; set; }


        public record PhoneNumberData
        {
            public int Id { get; set; }
            public string Number { get; set; }
            public PhoneNumberType NumberType { get; set; }
        }

        public record PersonRelationData
        {
            public int Id { get; set; }
            public int PersonId { get; set; }
            public string PersonName { get; set; }
            public PersonRelationType RelationType { get; set; }
        }
    }
}
