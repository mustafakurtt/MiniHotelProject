using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(u => u.Id);
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(r => r.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(r => r.UserOperationClaims)
            .WithOne(uoc => uoc.OperationClaim)
            .HasForeignKey(uoc => uoc.OperationClaimId);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private IEnumerable<OperationClaim> getSeeds()
    {
        List<OperationClaim> operationCliams = new();
        OperationClaim adminOperationClaim =
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Admin"
            };
        operationCliams.Add(adminOperationClaim);
        return operationCliams.ToArray();
    }
}