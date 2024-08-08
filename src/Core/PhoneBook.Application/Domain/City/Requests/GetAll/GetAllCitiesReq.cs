using PhoneBook.Application.Domain.City.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.City.Requests.GetAll
{
    public class GetAllCitiesReq : AppPageRequest<GetAllCitiesReq.Data>
    {
        public GetAllCitiesReq(string searchTerm)
        {
            Body = new Data(searchTerm);
        }

        public override string Name => CityRequestNames.GetAllCities;

        public record Data(string SearchTerm);
    }
}
