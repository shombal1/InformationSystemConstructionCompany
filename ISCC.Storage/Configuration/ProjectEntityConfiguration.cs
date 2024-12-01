using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISCC.Storage.Configuration;

public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.Plans)
            .WithOne(p => p.Project);
        
        // builder.HasMany(p => p.Resources)
        //     .WithOne(p => p.Project);
        
        builder.HasMany(p => p.GroupTasks)
            .WithOne(p => p.Project);
        
        builder.HasMany(p => p.OneTimeExpenses)
            .WithOne(p => p.Project);
        
        builder.HasMany(p => p.RegularExpenses)
            .WithOne(p => p.Project);
    }
}