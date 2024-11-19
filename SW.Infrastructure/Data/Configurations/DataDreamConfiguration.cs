using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SW.Domain.Entities;

namespace SW.Infrastructure.Data.Configurations;

public class DataDreamConfiguration : IEntityTypeConfiguration<DataDream>
{
    public void Configure(EntityTypeBuilder<DataDream> builder)
    {
        builder.Property(e => e.CreatedBy)
            .HasMaxLength(50)
            .HasDefaultValueSql("(N'Admin')");

        builder.Property(e => e.CreatedDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");

        builder.Property(e => e.StartTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        
        builder.Property(e => e.EndTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");

        builder.HasOne(d => d.UserData)
            .WithMany(p => p.DataDream)
            .HasForeignKey(d => d.UserDataId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_DataDream_UserData");
    }
}