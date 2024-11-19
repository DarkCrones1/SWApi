using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SW.Domain.Entities;

namespace SW.Infrastructure.Data.Configurations;

public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.Property(e => e.CreatedDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.Password).HasMaxLength(100);
        builder.Property(e => e.UserName).HasMaxLength(150);
        builder.Property(e => e.Email)
            .HasMaxLength(150)
            .IsUnicode(false);

        builder.HasMany(d => d.UserData).WithMany(p => p.UserAccount)
            .UsingEntity<Dictionary<string, object>>(
                "UserAccountUserData",
                r => r.HasOne<UserData>().WithMany()
                    .HasForeignKey("UserDataId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccountUserData_UserData"),
                l => l.HasOne<UserAccount>().WithMany()
                    .HasForeignKey("UserAccountId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccountUserData_UserAccount"),
                j =>
                {
                    j.HasKey("UserAccountId", "UserDataId");
                });
    }
}