using Microsoft.EntityFrameworkCore;
using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;
using SmartRun.Infrastructure.Data.Mappings;

namespace SmartRun.Infrastructure.Data;

public sealed class DataContext : DbContext
{
    public DbSet<Training> Trainings { get; set; }

    public DataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TrainingMapping());
        base.OnModelCreating(modelBuilder);
    }
}
