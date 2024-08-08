using PhoneBook.Application.Domain.Person;
using PhoneBook.Core.DAL;

namespace PhoneBook.Application.Domain.PhoneNumber
{
    public class PhoneNumberEntity : AppEntity<int>
    {
        public string Number { get; set; }
        public PhoneNumberType NumberType { get; set; }

        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }
    }
}
