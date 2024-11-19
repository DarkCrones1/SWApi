using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SW.Domain.Entities;

namespace SW.Infrastructure.Data.Configurations;

public class UserDataCommendConfiguration : IEntityTypeConfiguration<UserDataCommend>
{
    public void Configure(EntityTypeBuilder<UserDataCommend> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__UserDataCommend__3214EC07A20A3AD6");

        builder.HasOne(d => d.UserCommend).WithMany(p => p.UserDataCommend)
            .HasForeignKey(d => d.UserCommendId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_UserDataCommend_UserComment");

        builder.HasOne(d => d.UserData).WithMany(p => p.UserDataCommend)
            .HasForeignKey(d => d.UserDataId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_UserDataCommend_UserData");
    }
}