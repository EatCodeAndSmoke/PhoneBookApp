using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Localization;

namespace PhoneBook.Infrastructure.DAL.Config
{
    public class MeaningConfig : IEntityTypeConfiguration<AppMeaningEntity>
    {
        public void Configure(EntityTypeBuilder<AppMeaningEntity> builder)
        {
            builder.Property(x => x.Meaning).IsRequired();
            builder.HasOne(x => x.Word).WithMany(x => x.Meanings).HasForeignKey(x => x.WordId);

            builder.HasData(

                    // word 1
                    new AppMeaningEntity
                    {
                        Id = 1,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.GE,
                        Meaning = "ქალაქი ვერ მოიძებნა",
                        WordId = 1
                    },

                    new AppMeaningEntity
                    {
                        Id = 2,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.EN,
                        Meaning = "city not found",
                        WordId = 1
                    },

                    // word 2
                    new AppMeaningEntity
                    {
                        Id = 3,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.GE,
                        Meaning = "ფიზიკური პირი ასეთი მონაცემებით უკვე არსებობს",
                        WordId = 2
                    },

                    new AppMeaningEntity
                    {
                        Id = 4,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.EN,
                        Meaning = "person with similar data already exists",
                        WordId = 2
                    },

                    // word 3
                    new AppMeaningEntity
                    {
                        Id = 5,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.GE,
                        Meaning = "ფიზიკური პირი ვერ მოიძებნა",
                        WordId = 3
                    },

                    new AppMeaningEntity
                    {
                        Id = 6,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.EN,
                        Meaning = "person not found",
                        WordId = 3
                    },

                    // word 4
                    new AppMeaningEntity
                    {
                        Id = 7,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.GE,
                        Meaning = "ასეთი კავშირი უკვე არსებობს",
                        WordId = 4
                    },

                    new AppMeaningEntity
                    {
                        Id = 8,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.EN,
                        Meaning = "similar relation already exists",
                        WordId = 4
                    },

                    // word 5
                    new AppMeaningEntity
                    {
                        Id = 9,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.GE,
                        Meaning = "კავშირი ვერ მოიძება",
                        WordId = 5
                    },

                    new AppMeaningEntity
                    {
                        Id = 10,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.EN,
                        Meaning = "relation not found",
                        WordId = 5
                    },

                    // word 6
                    new AppMeaningEntity
                    {
                        Id = 11,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.GE,
                        Meaning = "ტელეფონის ნომერი უკვე არსებობს",
                        WordId = 6
                    },

                    new AppMeaningEntity
                    {
                        Id = 12,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.EN,
                        Meaning = "phone number already exists",
                        WordId = 6
                    },

                    // word 7
                    new AppMeaningEntity
                    {
                        Id = 13,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.GE,
                        Meaning = "ტელეფონის ნომერი ვერ მოიძებნა",
                        WordId = 7
                    },

                    new AppMeaningEntity
                    {
                        Id = 14,
                        CorrelationId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTimeOffset.UtcNow,
                        Lang = Core.AppLanguage.EN,
                        Meaning = "phone number not found",
                        WordId = 7
                    }
                );
        }
    }
}
