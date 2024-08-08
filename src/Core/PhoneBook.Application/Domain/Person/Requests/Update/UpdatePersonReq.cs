using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.Person.Requests.Update
{
    public class UpdatePersonReq : AppRequest<UpdatePersonReqBody>
    {
        public UpdatePersonReq(UpdatePersonReqBody data)
        {
            Body = data;
        }

        public override string Name => PersonRequestNames.Update;
    }

    public record UpdatePersonReqBody
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonGender Gender { get; set; }
        public string PersonalNumber { get; set; }
        public int CityId { get; set; }
    }
}
