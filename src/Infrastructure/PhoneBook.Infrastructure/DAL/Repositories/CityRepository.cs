using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Domain.City;

namespace PhoneBook.Infrastructure.DAL.Repositories
{
    public class CityRepository : AppRepository<CityEntity>, ICityRepository
    {
        public CityRepository(PhoneBookDbContext context) : base(context)
        {
        }

        public IQueryable<CityEntity> SearchQuery(string searchTerm)
        {
            return !string.IsNullOrWhiteSpace(searchTerm) ? QueryAll().Where(x => x.SearchTerm.Contains(searchTerm))
                                                          : QueryAll();   
        }

        public async Task<IEnumerable<CityEntity>> SearchAsync(string searchTerm)
        {
            return await SearchQuery(searchTerm).ToArrayAsync();
        }
    }
}
