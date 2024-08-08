using PhoneBook.Application.Domain.Person;
using PhoneBook.Core.DAL;

namespace PhoneBook.Application.Domain.City
{
    public class CityEntity : AppEntity<int>
    {
        public string NameGe { get; set; }
        public string NameEng { get; set; }
        public string SearchTerm { get; set; }

        public ICollection<PersonEntity> People { get; set; }
    }
}
