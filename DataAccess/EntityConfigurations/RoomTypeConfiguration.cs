using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("RoomTypes").HasKey(rt => rt.Id);
        builder.Property(rt => rt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rt => rt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rt => rt.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(rt => rt.Description).HasColumnName("DeletedDate").IsRequired();
        builder.Property(rt => rt.MaxGuestCount).HasColumnName("MaxGuestCount").IsRequired();
        builder.Property(rt => rt.ImageUrl).HasColumnName("ImageUrl");

        builder.HasMany(r => r.Rooms);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

    }
}