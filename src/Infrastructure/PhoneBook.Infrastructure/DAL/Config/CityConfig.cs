using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Application.Domain.City;

namespace PhoneBook.Infrastructure.DAL.Config
{
    public class CityConfig : IEntityTypeConfiguration<CityEntity>
    {
        
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.Property(x => x.NameGe)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.NameEng)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.SearchTerm)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasData(
                new CityEntity
                {
                    Id = 1,
                    NameEng = "Tbilisi",
                    NameGe = "თბილისი",
                    SearchTerm = "Tbilisiთბილისი",
                    CreatedAt = DateTimeOffset.UtcNow,
                    CorrelationId = Guid.NewGuid().ToString(),
                },

                 new CityEntity
                 {
                     Id = 2,
                     NameEng = "Kutaisi",
                     NameGe = "ქუთაისი",
                     SearchTerm = "Kutaisiქუთაისი",
                     CreatedAt = DateTimeOffset.UtcNow,
                     CorrelationId = Guid.NewGuid().ToString(),
                 }
            );
        }
    }
}
