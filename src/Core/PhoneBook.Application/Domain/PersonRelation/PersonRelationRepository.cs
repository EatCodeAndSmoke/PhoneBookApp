using PhoneBook.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Domain.PersonRelation
{
    public interface IPersonRelationRepository : IAppRepository<PersonRelationEntity>
    {
        IQueryable<PersonRelationEntity> QueryAllByPerson(int personId);
        Task<IEnumerable<PersonRelationEntity>> GetAllByPersonAsync(int personId);
        Task<bool> RelationExistsAsync(int primaryPers, int secondPers, PersonRelationType relationType);
    }
}
