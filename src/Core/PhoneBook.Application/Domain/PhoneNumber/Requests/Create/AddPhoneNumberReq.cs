using PhoneBook.Application.Domain.PhoneNumber.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.PhoneNumber.Requests.Create
{
    public class AddPhoneNumberReq : AppRequest<AddPhoneNumberReqBody>
    {
        public AddPhoneNumberReq(AddPhoneNumberReqBody data)
        {
            Body = data;
        }

        public override string Name => PNRequestNames.Create;
    }

    public record AddPhoneNumberReqBody
    {
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneNumberType NumberType { get; set; }
    }
}
