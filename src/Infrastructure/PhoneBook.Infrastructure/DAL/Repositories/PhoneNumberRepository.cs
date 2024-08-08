using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Common.Models;
using PhoneBook.Application.Domain.PhoneNumber;

namespace PhoneBook.Infrastructure.DAL.Repositories
{
    public class PhoneNumberRepository : AppRepository<PhoneNumberEntity>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(PhoneBookDbContext context) : base(context)
        {
        }

        public IQueryable<PhoneNumberEntity> QueryAllByPerson(int personId)
        {
            return QueryAll().Where(x => x.PersonId == personId);
        }

        public async Task<IEnumerable<PhoneNumberEntity>> GetAllByPersonAsync(int personId)
        {
            return await QueryAllByPerson(personId).ToListAsync();
        }

        public async Task<bool> PhoneNumberExistsAsync(int personId, PhoneModel model)
        {
            return await QueryAllByPerson(personId)
                        .AnyAsync(x => x.Number == model.Number && x.NumberType == model.NumberType);
        }
    }
}
