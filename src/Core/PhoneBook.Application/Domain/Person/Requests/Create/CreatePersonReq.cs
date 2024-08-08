using PhoneBook.Application.Common.Models;
using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.Person.Requests.Create
{
    public class CreatePersonReq : AppRequest<CreatePersonReqBody>
    {
        public CreatePersonReq(CreatePersonReqBody data)
        {
            ArgumentNullException.ThrowIfNull(data, nameof(data));
            Body = data;
        }

        public override string Name => PersonRequestNames.Create;
    }

    public record CreatePersonReqBody(
            string FirstName,
            string LastName,
            PersonGender Gender,
            string PersonalNumber,
            int CityId,
            FileModel File
        );
}
