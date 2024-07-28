using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfigurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("RoomTypes").HasKey(rt => rt.Id);
        builder.Property(rt => rt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rt => rt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rt => rt.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(rt => rt.Description).HasColumnName("Description").IsRequired();
        builder.Property(rt => rt.Name).HasColumnName("Name").IsRequired();
        builder.Property(rt => rt.MaxGuestCount).HasColumnName("MaxGuestCount").IsRequired();
        builder.Property(rt => rt.ImageUrl).HasColumnName("ImageUrl");

        builder.HasMany(rt => rt.Rooms).WithOne(r => r.RoomType).HasForeignKey(r => r.RoomTypeId);
        builder.HasQueryFilter(rt => !rt.DeletedDate.HasValue);
    }
}