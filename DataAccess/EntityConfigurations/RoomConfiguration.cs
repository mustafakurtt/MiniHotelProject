using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms").HasKey(r => r.Id);
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(r => r.RoomNumber).HasColumnName("RoomNumber").IsRequired();
        builder.Property(r => r.RoomStatus).HasColumnName("RoomStatus").IsRequired();

        builder.HasOne(r => r.RoomType);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

    }
}