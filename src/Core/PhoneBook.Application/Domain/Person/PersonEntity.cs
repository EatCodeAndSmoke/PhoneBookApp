using PhoneBook.Application.Domain.City;
using PhoneBook.Application.Domain.PersonRelation;
using PhoneBook.Application.Domain.PhoneNumber;
using PhoneBook.Core.DAL;

namespace PhoneBook.Application.Domain.Person
{
    public class PersonEntity : AppEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonGender Gender { get; set; }
        public string PersonalNumber { get; set; }
        public string PhotoUrl { get; set; }
        public string SearchTerm { get; set; }

        public int CityId { get; set; }
        public CityEntity City { get; set; }

        public ICollection<PersonRelationEntity> PrimaryRelations { get; set; }
        public ICollection<PersonRelationEntity> SecondaryRelations { get; set; }
        public ICollection<PhoneNumberEntity> PhoneNumbers { get; set; }
    }
}
