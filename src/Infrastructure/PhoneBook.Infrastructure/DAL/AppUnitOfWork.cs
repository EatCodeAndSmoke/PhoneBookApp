using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.DAL;

namespace PhoneBook.Infrastructure.DAL
{
    public class AppUnitOfWork : AppUnitOfWorkBase
    {
        private readonly DbContext _context;

        public AppUnitOfWork(IServiceProvider provider, PhoneBookDbContext context) : base(provider)
        {
            _context = context;
        }

        public async override Task SaveAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync();
        }
    }
}
