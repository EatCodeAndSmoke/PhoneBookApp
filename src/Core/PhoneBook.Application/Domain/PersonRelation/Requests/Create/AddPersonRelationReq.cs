using PhoneBook.Application.Domain.PersonRelation.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.PersonRelation.Requests.Create
{
    public class AddPersonRelationReq : AppRequest<AddPersonRelationReqBody>
    {
        public AddPersonRelationReq(AddPersonRelationReqBody data)
        {
            Body = data;
        }

        public override string Name => PRRequestNames.Create;
    }

    public record AddPersonRelationReqBody
    {
        public int PrimaryPersonId { get; set; }
        public int SecondaryPersonId { get; set; }
        public PersonRelationType RelationType { get; set; }
    }
}
