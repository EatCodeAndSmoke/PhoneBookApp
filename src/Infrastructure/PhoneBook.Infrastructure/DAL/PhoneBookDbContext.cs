using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Domain.City;
using PhoneBook.Application.Domain.Person;
using PhoneBook.Application.Domain.PersonRelation;
using PhoneBook.Application.Domain.PhoneNumber;
using PhoneBook.Core.Localization;
using PhoneBook.Infrastructure.DAL.Config;

namespace PhoneBook.Infrastructure.DAL
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options)
        {            
        }

        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<PersonRelationEntity> Relations { get; set; }
        public DbSet<PhoneNumberEntity> PhoneNumbers { get; set; }
        public DbSet<AppWordEntity> Words { get; set; }
        public DbSet<AppMeaningEntity> Meanings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WordConfig).Assembly);
        }
    }
}
