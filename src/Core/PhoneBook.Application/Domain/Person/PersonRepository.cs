using PhoneBook.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Domain.Person
{
    public interface IPersonRepository : IAppRepository<PersonEntity>
    {
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByPersonalIdAsync(string personalId);
        Task<PersonEntity> GetByPersonalIdAsync(string personalId);
    }
}
