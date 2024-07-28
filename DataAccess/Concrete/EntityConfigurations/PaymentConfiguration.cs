using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments").HasKey(p => p.Id);
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(p => p.Amount).HasColumnName("Amount").IsRequired();
        builder.Property(p => p.PaymentDate).HasColumnName("PaymentDate").IsRequired();
        builder.Property(p => p.PaymentMethod).HasColumnName("PaymentMethod").IsRequired();
        builder.Property(p => p.ReservationId).HasColumnName("ReservationId").IsRequired();

        builder.HasOne(p => p.Reservation).WithOne(r => r.Payment).HasForeignKey<Payment>(p => p.ReservationId);
        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}