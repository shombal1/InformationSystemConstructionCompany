using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISCC.Storage.Configuration;

public class ProjectPlanEntityConfiguration : IEntityTypeConfiguration<ProjectPlanEntity>
{
    public void Configure(EntityTypeBuilder<ProjectPlanEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Project)
            .WithMany(p => p.Plans)
            .HasForeignKey(p => p.ProjectId);

        builder.HasMany(p => p.Resources)
            .WithOne(p => p.ProjectPlan);
    }
}