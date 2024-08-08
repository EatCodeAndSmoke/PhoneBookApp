using PhoneBook.Application.Domain.PhoneNumber.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.PhoneNumber.Requests.Remove
{
    public class RemovePhoneNumberReq : AppRequest<RemovePhoneNumberReqBody>
    {
        public RemovePhoneNumberReq(int id)
        {
            Body = new RemovePhoneNumberReqBody(id);
        }

        public override string Name => PNRequestNames.Remove;
    }

    public record RemovePhoneNumberReqBody(int Id);
}
