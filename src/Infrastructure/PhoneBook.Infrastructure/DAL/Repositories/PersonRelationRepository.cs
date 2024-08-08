using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Domain.PersonRelation;

namespace PhoneBook.Infrastructure.DAL.Repositories
{
    public class PersonRelationRepository : AppRepository<PersonRelationEntity>, IPersonRelationRepository
    {
        public PersonRelationRepository(PhoneBookDbContext context) : base(context)
        {
        }

        public IQueryable<PersonRelationEntity> QueryAllByPerson(int personId)
        {
            return QueryAll().Where(x => x.PrimaryPersonId == personId);
        }

        public async Task<IEnumerable<PersonRelationEntity>> GetAllByPersonAsync(int personId)
        {
            return await QueryAllByPerson(personId).ToListAsync();
        }

        public async Task<bool> RelationExistsAsync(int primaryPers, int secondPers, PersonRelationType relationType)
        {
            return await QueryAll().AnyAsync(x => x.PrimaryPersonId == primaryPers &&
                                                  x.SecondaryPersonId == secondPers &&
                                                  x.RelationType == relationType);
        }
    }
}
