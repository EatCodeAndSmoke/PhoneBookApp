using PhoneBook.Application.Common.Models;
using PhoneBook.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Domain.PhoneNumber
{
    public interface IPhoneNumberRepository : IAppRepository<PhoneNumberEntity>
    {
        IQueryable<PhoneNumberEntity> QueryAllByPerson(int personId);
        Task<IEnumerable<PhoneNumberEntity>> GetAllByPersonAsync(int personId);
        Task<bool> PhoneNumberExistsAsync(int personId, PhoneModel model);
    }
}
