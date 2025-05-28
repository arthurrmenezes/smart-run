using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;

namespace SmartRun.Infrastructure.Data.Mappings;

public sealed class TrainingMapping : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.Property(t => t.Location)
            .HasConversion<string>();
    }
}
