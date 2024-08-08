using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Application.Domain.City.Constants;
using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Application.Domain.PersonRelation.Constants;
using PhoneBook.Application.Domain.PhoneNumber.Constants;
using PhoneBook.Core;
using PhoneBook.Core.Localization;

namespace PhoneBook.Infrastructure.DAL.Config
{
    public class WordConfig : IEntityTypeConfiguration<AppWordEntity>
    {
        public void Configure(EntityTypeBuilder<AppWordEntity> builder)
        {
            builder.HasIndex(x => x.Code).IsUnique();

            builder.HasData(
                    new AppWordEntity
                    {
                        Id = 1,
                        Code = CityErrorCodes.NotFound,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                    },

                    new AppWordEntity
                    {
                        Id = 2,
                        Code = PersonErrorCodes.AlreadyExists,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                    },

                    new AppWordEntity
                    {
                        Id = 3,
                        Code = PersonErrorCodes.NotFound,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                    },

                    new AppWordEntity
                    {
                        Id = 4,
                        Code = PRErrorCodes.AlreadyExists,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                    },

                    new AppWordEntity
                    {
                        Id = 5,
                        Code = PRErrorCodes.NotFound,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                    },

                    new AppWordEntity
                    {
                        Id = 6,
                        Code = PNErrorCodes.AlreadyExists,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                    },

                    new AppWordEntity
                    {
                        Id = 7,
                        Code = PNErrorCodes.NotFound,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                    }
                );
        }
    }
}
