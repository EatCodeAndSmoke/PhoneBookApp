using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Domain.Person.Requests.GetAll
{
    public record GetAllPersonResp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonGender Gender { get; set; }
        public string PersonalNumber { get; set; }
        public int CityId { get; set; }
    }
}
