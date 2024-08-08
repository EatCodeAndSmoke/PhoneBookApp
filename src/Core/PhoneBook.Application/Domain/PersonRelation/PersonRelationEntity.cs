using PhoneBook.Application.Domain.Person;
using PhoneBook.Core.DAL;

namespace PhoneBook.Application.Domain.PersonRelation
{
    public class PersonRelationEntity : AppEntity<int>
    {
        public PersonRelationType RelationType { get; set; }

        public int PrimaryPersonId { get; set; }
        public PersonEntity PrimaryPerson { get; set; }

        public int SecondaryPersonId { get; set; }
        public PersonEntity SecondaryPerson { get; set; }
    }
}
