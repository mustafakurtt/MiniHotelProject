using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfigurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations").HasKey(r => r.Id);
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(r => r.CheckIDate).HasColumnName("CheckIDate");
        builder.Property(r => r.CheckOutDate).HasColumnName("CheckOutDate");
        builder.Property(r => r.IsSavedToKBS).HasColumnName("IsSavedToKBS");
        builder.Property(r => r.CheckedIn).HasColumnName("CheckedIn");
        builder.Property(r => r.CheckedOut).HasColumnName("CheckedOut");
        builder.Property(r => r.RoomId).HasColumnName("RoomId");
        builder.Property(r => r.PaymentId).HasColumnName("PaymentId");

        builder.HasOne(r => r.Room).WithMany(rm => rm.Reservations).HasForeignKey(r => r.RoomId);
        builder.HasOne(r => r.Payment).WithOne(p => p.Reservation).HasForeignKey<Reservation>(r => r.PaymentId);
        builder.HasMany(r => r.ReservationGuests).WithOne(rg => rg.Reservation).HasForeignKey(rg => rg.ReservationId);
        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}