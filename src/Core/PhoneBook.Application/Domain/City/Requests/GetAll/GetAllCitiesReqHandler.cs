using PhoneBook.Application.Domain.City.Requests.GetAll;
using PhoneBook.Core;
using PhoneBook.Core.Extensions;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.City.Requests.GetAllCities
{
    public class GetAllCitiesReqHandler : AppRequestHandler<GetAllCitiesReq>
    {
        private readonly ICityRepository _cityRepository;

        public GetAllCitiesReqHandler(IServiceProvider services, ICityRepository cityRepository) : base(services)
        {
            _cityRepository = cityRepository;
        }

        public override async ValueTask<AppOutput> HandleAsync(GetAllCitiesReq input, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (await Cache.TryGetAsync("some-cache-key", out IEnumerable<CityEntity> cities))
            {
                var result = string.IsNullOrWhiteSpace(input.Body.SearchTerm)
                             ? cities : cities.Where(x => x.SearchTerm.Contains(input.Body.SearchTerm?.Trim(), StringComparison.CurrentCultureIgnoreCase));

                var page = GetPage(input, result);
                return Ok(page);
            }
            else
            {
                var result = await _cityRepository.QueryAll().ToListAsync();
                await Cache.SetAsync("some-cache-key", result, x => x.WithExpiration(TimeSpan.FromSeconds(30)));

                result = string.IsNullOrWhiteSpace(input.Body.SearchTerm)
                         ? result : result.Where(x => x.SearchTerm.Contains(input.Body.SearchTerm?.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();

                var page = GetPage(input, result);
                return Ok(page);
            }
        }

        private static AppPageResult<GetAllCitiesResp> GetPage(GetAllCitiesReq input, IEnumerable<CityEntity> result)
        {
            return result.Select(x => new GetAllCitiesResp
            {
                Id = x.Id,
                Name = input.Lang == AppLanguage.GE ? x.NameGe : x.NameEng
            })
            .ToArray()
            .ToPage(input.PageNumber, input.RecordsOnPage);
        }
    }
}
