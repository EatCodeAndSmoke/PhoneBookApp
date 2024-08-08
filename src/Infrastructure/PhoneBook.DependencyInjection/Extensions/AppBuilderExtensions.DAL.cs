using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.DAL;
using PhoneBook.Application.Domain.City;
using PhoneBook.Infrastructure.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using PhoneBook.Application.Domain.PersonRelation;
using PhoneBook.Application.Domain.Person;
using PhoneBook.Application.Domain.PhoneNumber;

namespace PhoneBook.DependencyInjection.Extensions
{
    public static partial class AppBuilderExtensions
    {
        public static PhoneBookAppBuilder AddDAL(this PhoneBookAppBuilder builder, IConfiguration config) 
        {
            builder.Services.AddDbContextPool<PhoneBookDbContext>(x =>
            {
                x.UseSqlServer(config.GetConnectionString("Default"));
            });

            builder.Services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<IAppRepository<CityEntity>, CityRepository>();

            builder.Services.AddScoped<IPersonRelationRepository, PersonRelationRepository>();
            builder.Services.AddScoped<IAppRepository<PersonRelationEntity>, PersonRelationRepository>();

            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IAppRepository<PersonEntity>, PersonRepository>();

            builder.Services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
            builder.Services.AddScoped<IAppRepository<PhoneNumberEntity>, PhoneNumberRepository>();
            return builder;
        }
    }
}
