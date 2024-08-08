using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Application.Domain.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.DAL.Config
{
    public class PersonConfig : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.PersonalNumber)
                   .IsRequired()
                   .HasMaxLength(11)
                   .IsFixedLength();

            builder.HasIndex(x => x.PersonalNumber)
                   .IsUnique();

            builder.Property(x => x.PhotoUrl)
                   .IsRequired();

            builder.Property(x => x.SearchTerm)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasOne(x => x.City)
                   .WithMany(x => x.People)
                   .HasForeignKey(x => x.CityId);

        }
    }
}
