using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SW.Domain.Entities;

namespace SW.Infrastructure.Data.Configurations;

public class UserCommendConfiguration : IEntityTypeConfiguration<UserCommend>
{
    public void Configure(EntityTypeBuilder<UserCommend> builder)
    {
        builder.Property(e => e.CreatedBy)
            .HasMaxLength(20)
            .HasDefaultValueSql("(N'Admin')");
        builder.Property(e => e.CreatedDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.LastModifiedBy).HasMaxLength(20);
        builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");
        builder.Property(e => e.Name).HasMaxLength(150);
    }
}