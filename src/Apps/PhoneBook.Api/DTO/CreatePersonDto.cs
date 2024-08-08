using PhoneBook.Application.Common.Models;
using PhoneBook.Application.Domain.Person;
using PhoneBook.Application.Domain.Person.Requests.Create;

namespace PhoneBook.Api.DTO
{
    public record CreatePersonDto(string FirstName,
                string LastName,
                PersonGender Gender,
                string PersonalNumber,
                int CityId,
                IFormFile Photo);
}
