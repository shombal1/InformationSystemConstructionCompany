using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISCC.Storage.Configuration;

public class ResourceEntityConfiguration : IEntityTypeConfiguration<ResourceEntity>
{
    public void Configure(EntityTypeBuilder<ResourceEntity> builder)
    {
        builder.HasKey(r => r.Id);

        // builder.HasOne(r => r.Project)
        //     .WithMany(r => r.Resources)
        //     .HasForeignKey(r => r.ProjectId);
        
        builder.HasOne(r => r.ProjectPlan)
            .WithMany(r => r.Resources)
            .HasForeignKey(r => r.ProjectPlanId);
        
        builder.HasOne(r => r.UnitType)
            .WithMany(r => r.Resources)
            .HasForeignKey(r => r.UnitTypeId);
    }
}