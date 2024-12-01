using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISCC.Storage.Configuration;

public class GroupTaskEntityConfiguration : IEntityTypeConfiguration<GroupTaskEntity>
{
    public void Configure(EntityTypeBuilder<GroupTaskEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(g => g.Project)
            .WithMany(p => p.GroupTasks)
            .HasForeignKey(g => g.ProjectId);
        
        builder.HasMany(p => p.Tasks)
            .WithOne(p => p.GroupTask);

        builder.HasOne(gt => gt.ParentGroup)
            .WithMany(pg => pg.SubGroups)
            .HasForeignKey(gt => gt.ParentGroupId);

        builder.HasMany(gt => gt.SubGroups)
            .WithOne(t => t.ParentGroup);
    }
}