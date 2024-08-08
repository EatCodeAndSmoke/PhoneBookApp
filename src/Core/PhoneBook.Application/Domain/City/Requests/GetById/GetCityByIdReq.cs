using PhoneBook.Application.Domain.City.Constants;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.City.Requests.GetById
{
    public class GetCityByIdReq : AppRequest<GetCityByIdReq.Data>
    {
        public GetCityByIdReq(int id)
        {
            Body = new Data(id);
        }

        public override string Name => CityRequestNames.GetById;

        public record Data(int Id);
    }
}
