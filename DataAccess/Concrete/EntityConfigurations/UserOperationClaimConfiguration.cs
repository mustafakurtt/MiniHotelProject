using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(u => u.Id);
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(r => r.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(r => r.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.HasOne(r => r.OperationClaim)
            .WithMany(oc => oc.UserOperationClaims)
            .HasForeignKey(r => r.OperationClaimId);
        builder.HasOne(r => r.User)
            .WithMany(u => u.UserOperationClaims)
            .HasForeignKey(r => r.UserId);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private IEnumerable<UserOperationClaim> getSeeds()
    {
        List<UserOperationClaim> userOperationCliams = new();
        UserOperationClaim userOperationClaim =
            new()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                OperationClaimId = Guid.NewGuid()
            };
        userOperationCliams.Add(userOperationClaim);
        return userOperationCliams.ToArray();
    }
}