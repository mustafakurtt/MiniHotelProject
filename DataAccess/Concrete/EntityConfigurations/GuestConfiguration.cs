using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfigurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests").HasKey(g => g.Id);
        builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(g => g.Name).HasColumnName("Name");
        builder.Property(g => g.Surname).HasColumnName("Surname");
        builder.Property(g => g.DateOfBirth).HasColumnName("DateOfBirth");
        builder.Property(g => g.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(g => g.NationalityId).HasColumnName("NationalityId");
        builder.Property(g => g.CountryCode).HasColumnName("CountryCode");
        builder.Property(g => g.PassportNumber).HasColumnName("PassportNumber");

        builder.HasMany(g => g.ReservationGuests).WithOne(rg => rg.Guest);
        builder.HasQueryFilter(g => !g.DeletedDate.HasValue);
    }
}