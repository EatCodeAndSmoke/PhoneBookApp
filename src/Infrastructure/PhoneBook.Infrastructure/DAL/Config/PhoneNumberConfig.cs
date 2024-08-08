using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Application.Domain.PhoneNumber;

namespace PhoneBook.Infrastructure.DAL.Config
{
    public class PhoneNumberConfig : IEntityTypeConfiguration<PhoneNumberEntity>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberEntity> builder)
        {
            builder.Property(x => x.Number).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Person)
                   .WithMany(x => x.PhoneNumbers)
                   .HasForeignKey(x => x.PersonId);
        }
    }
}
