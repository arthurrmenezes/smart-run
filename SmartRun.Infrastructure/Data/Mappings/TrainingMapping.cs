using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;
using SmartRun.Domain.ValueObjects;

namespace SmartRun.Infrastructure.Data.Mappings;

public sealed class TrainingMapping : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.ToTable("trainings");

        builder.HasKey(t => t.Id);

        #region Properties Configuration

        builder.Property(t => t.Id)
            .IsRequired(true)
            .HasConversion(t => t.Id, value => IdValueObject.Factory(value))
            .ValueGeneratedNever();
        builder.Property(t => t.Location)
            .IsRequired(true)
            .HasConversion<string>()
            .HasMaxLength(50)
            .ValueGeneratedNever();
        builder.Property(t => t.Distance)
            .IsRequired(true)
            .ValueGeneratedNever();
        builder.Property(t => t.Duration)
            .IsRequired(true)
            .ValueGeneratedNever();
        builder.Property(t => t.Date)
            .IsRequired(true)
            .ValueGeneratedNever();
        builder.Property(t => t.CreatedAt)
            .IsRequired(true);
        builder.Property(t => t.AccountId)
            .IsRequired(true)
            .HasConversion(t => t.Id, value => IdValueObject.Factory(value))
            .ValueGeneratedNever();
        
        #endregion
    }
}
