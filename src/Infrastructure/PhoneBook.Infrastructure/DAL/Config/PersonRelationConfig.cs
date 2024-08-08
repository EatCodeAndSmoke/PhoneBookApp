using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Application.Domain.PersonRelation;

namespace PhoneBook.Infrastructure.DAL.Config
{
    public class PersonRelationConfig : IEntityTypeConfiguration<PersonRelationEntity>
    {
        public void Configure(EntityTypeBuilder<PersonRelationEntity> builder)
        {
            builder.HasOne(x => x.PrimaryPerson)
                   .WithMany(x => x.PrimaryRelations)
                   .HasForeignKey(x => x.PrimaryPersonId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SecondaryPerson)
                  .WithMany(x => x.SecondaryRelations)
                  .HasForeignKey(x => x.SecondaryPersonId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
