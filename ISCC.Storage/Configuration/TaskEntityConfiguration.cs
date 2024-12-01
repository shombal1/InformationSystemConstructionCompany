using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISCC.Storage.Configuration;

public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.GroupTask)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.GroupId);

        builder.HasOne(t => t.ProjectPlan)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectPlanId);
    }
}