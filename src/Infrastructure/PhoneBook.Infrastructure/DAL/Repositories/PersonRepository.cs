using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Domain.Person;

namespace PhoneBook.Infrastructure.DAL.Repositories
{
    public class PersonRepository : AppRepository<PersonEntity>, IPersonRepository
    {
        public PersonRepository(PhoneBookDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await QueryAll().AnyAsync(x => x.Id == id);  
        }

        public async Task<bool> ExistsByPersonalIdAsync(string personalId)
        {
            return await QueryAll().AnyAsync(x => x.PersonalNumber == personalId);
        }

        public async Task<PersonEntity> GetByPersonalIdAsync(string personalId)
        {
            return await QueryAll().FirstOrDefaultAsync(x => x.PersonalNumber == personalId);
        }
    }
}
