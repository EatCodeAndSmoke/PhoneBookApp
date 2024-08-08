using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.Person.Requests.GetById
{
    public class GetPersonByIdReq : AppRequest<GetPersonByIdReq.Data>
    {
        public GetPersonByIdReq(int id)
        {
            Body = new Data(id);
        }

        public override string Name => PersonRequestNames.GetById;

        public record Data(int Id);
    }
}
