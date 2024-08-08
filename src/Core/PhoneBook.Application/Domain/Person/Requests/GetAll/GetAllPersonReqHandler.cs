using PhoneBook.Core;
using PhoneBook.Core.Extensions;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.Person.Requests.GetAll
{
    public class GetAllPersonReqHandler : AppRequestHandler<GetAllPersonReq>
    {
        public GetAllPersonReqHandler(IServiceProvider services) : base(services)
        {
        }

        public override async ValueTask<AppOutput> HandleAsync(GetAllPersonReq input, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (await Cache.TryGetAsync("person-cache-key", out IEnumerable<PersonEntity> people))
            {
                var result = string.IsNullOrWhiteSpace(input.Body.SearchTerm)
                             ? people : people.Where(x => x.SearchTerm.Contains(input.Body.SearchTerm?.Trim(), StringComparison.CurrentCultureIgnoreCase));

                var page = GetPage(input, result);
                return Ok(page);
            }
            else
            {
                var query = await UnitOfWork.QueryAll<PersonEntity>().ToListAsync();
                await Cache.SetAsync("person-cache-key", query, x => x.WithExpiration(TimeSpan.FromSeconds(30)));

                var result = string.IsNullOrWhiteSpace(input.Body.SearchTerm)
                             ? query : query.Where(x => x.SearchTerm.Contains(input.Body.SearchTerm?.Trim(), StringComparison.CurrentCultureIgnoreCase));

                var page = GetPage(input, result);
                return Ok(page);
            }
        }

        private static AppPageResult<GetAllPersonResp> GetPage(GetAllPersonReq input, IEnumerable<PersonEntity> result)
        {
            return result.Select(x => new GetAllPersonResp
            {
                Id = x.Id,
                CityId = x.CityId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                PersonalNumber = x.PersonalNumber
            })
            .ToArray()
            .ToPage(input.PageNumber, input.RecordsOnPage);
        }
    }
}
