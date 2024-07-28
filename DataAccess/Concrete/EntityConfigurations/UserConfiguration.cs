using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(r => r.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(r => r.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(r => r.Email).HasColumnName("Email").IsRequired();
        builder.Property(r => r.UserCode).HasColumnName("UserCode").IsRequired();
        builder.Property(r => r.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(r => r.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(r => r.Status).HasColumnName("Status").IsRequired();

        builder.HasMany(r => r.UserOperationClaims)
            .WithOne(uoc => uoc.User)
            .HasForeignKey(uoc => uoc.UserId);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasData(getSeeds());

    }

    private IEnumerable<User> getSeeds()    
    {
        List<User> users = new();
        HashingHelper.CreatePasswordHash(
            password: "Passw0rd",
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        User adminUser =
            new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                UserCode = "161055",
                CreatedDate = DateTime.UtcNow,
                Status = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        users.Add(adminUser);

        return users.ToArray();
    }
}