using Microsoft.EntityFrameworkCore;
using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;
using SmartRun.Infrastructure.Data.Mappings;

namespace SmartRun.Infrastructure.Data;

public sealed class DataContext : DbContext
{
    public DbSet<Training> Trainings { get; set; }

    public DataContext(DbContextOptions<DataContext> dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TrainingMapping());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=ULTRANOTE;Initial Catalog=SmartRun;Integrated Security=True;Trust Server Certificate=True");
    }
}
