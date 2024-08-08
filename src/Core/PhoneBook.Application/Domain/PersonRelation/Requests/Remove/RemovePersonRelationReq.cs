using PhoneBook.Application.Domain.PersonRelation.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.PersonRelation.Requests.Remove
{
    public class RemovePersonRelationReq : AppRequest<RemovePersonRelationReqBody>
    {
        public RemovePersonRelationReq(int id)
        {
            Body = new RemovePersonRelationReqBody(id);
        }

        public override string Name => PRRequestNames.Create;
    }

    public record RemovePersonRelationReqBody(int Id);
}
