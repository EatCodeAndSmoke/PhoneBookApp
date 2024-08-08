using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.Person.Requests.GetAll
{
    public class GetAllPersonReq : AppPageRequest<GetAllPersonReq.Data>
    {
        public GetAllPersonReq(string SearchTerm)
        {
            Body = new Data(SearchTerm);
        }

        public override string Name => PersonRequestNames.GetAll;

        public record Data(string SearchTerm);
    }
}
