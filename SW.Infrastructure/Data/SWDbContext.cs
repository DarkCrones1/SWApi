using Microsoft.EntityFrameworkCore;

using SW.Domain.Entities;

namespace SW.Infrastructure.Data;

public partial class SWDbContext : DbContext
{
    public SWDbContext()
    {
    }
    
    public SWDbContext(DbContextOptions<SWDbContext> options) : base(options)
    {
    }

    public virtual DbSet<DataDream> DataDream { get; set; }

    public virtual DbSet<UserAccount> UserAccount { get; set; }

    public virtual DbSet<UserCommend> UserCommend { get; set; }

    public virtual DbSet<UserData> UserData { get; set; }

    public virtual DbSet<ActiveUserAccount> ActiveUserAccount { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            option => option.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).MigrationsAssembly("SW.Api")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SWDbContext).Assembly);
    }
}