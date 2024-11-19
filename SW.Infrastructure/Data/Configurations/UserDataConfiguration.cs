using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SW.Domain.Entities;

namespace SW.Infrastructure.Data.Configurations;

public class UserDataConfiguration : IEntityTypeConfiguration<UserData>
{
    public void Configure(EntityTypeBuilder<UserData> builder)
    {
        // Don't Delete, Manual configuration
        builder.Ignore(x => x.FullName);

        builder.HasKey(e => e.Id).HasName("PK_UserData_3214EC076D7D9088");

        builder.Property(e => e.CellPhone)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.CreatedBy)
            .HasMaxLength(50)
            .HasDefaultValueSql("(N'User')");
        builder.Property(e => e.CreatedDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.FirstName)
            .HasMaxLength(200)
            .IsUnicode(false);
        builder.Property(e => e.LastModifiedBy).HasMaxLength(50);
        builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");
        builder.Property(e => e.LastName)
            .HasMaxLength(200)
            .IsUnicode(false);
        builder.Property(e => e.MiddleName)
            .HasMaxLength(150)
            .IsUnicode(false);
        builder.Property(e => e.Phone)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}