using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfigurations;

public class ReservationGuestConfiguration : IEntityTypeConfiguration<ReservationGuest>
{
    public void Configure(EntityTypeBuilder<ReservationGuest> builder)
    {
        builder.ToTable("ReservationGuests").HasKey(rg => rg.Id);
        builder.Property(rg => rg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rg => rg.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rg => rg.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(rg => rg.ReservationId).HasColumnName("ReservationId").IsRequired();
        builder.Property(rg => rg.GuestId).HasColumnName("GuestId").IsRequired();

        builder.HasOne(rg => rg.Reservation).WithMany(r => r.ReservationGuests).HasForeignKey(rg => rg.ReservationId);
        builder.HasOne(rg => rg.Guest).WithMany(g => g.ReservationGuests).HasForeignKey(rg => rg.GuestId);
        builder.HasQueryFilter(rg => !rg.DeletedDate.HasValue);
    }
}