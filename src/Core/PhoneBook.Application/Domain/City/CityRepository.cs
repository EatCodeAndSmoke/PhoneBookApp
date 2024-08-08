using PhoneBook.Core.DAL;

namespace PhoneBook.Application.Domain.City
{
    public interface ICityRepository : IAppRepository<CityEntity>
    {
        IQueryable<CityEntity> SearchQuery(string searchTerm);
        Task<IEnumerable<CityEntity>> SearchAsync(string searchTerm);
    }
}
