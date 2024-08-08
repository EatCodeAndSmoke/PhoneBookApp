using PhoneBook.Application.Domain.City.Constants;
using PhoneBook.Core;
using PhoneBook.Core.Extensions;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.City.Requests.GetById
{
    public class GetCityByIdReqHandler : AppRequestHandler<GetCityByIdReq>
    {
        public GetCityByIdReqHandler(IServiceProvider services) : base(services)
        {
        }

        public override async ValueTask<AppOutput> HandleAsync(GetCityByIdReq input, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await UnitOfWork.QueryAll<CityEntity>()
                                         .Select(x => new GetCityByIdResp
                                         {
                                             Id = x.Id,
                                             CreatedAt = x.CreatedAt,
                                             Name = input.Lang == AppLanguage.GE ? x.NameGe : x.NameEng
                                         })
                                         .FirstOrDefaultAsync(x => x.Id == input.Body.Id);

            return result == null ? BadRequest(CityErrorCodes.NotFound) : Ok(result);
        }                               
    }
}
