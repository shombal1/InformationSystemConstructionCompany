using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISCC.Storage.Configuration;

public class RegularExpenseConfiguration: IEntityTypeConfiguration<RegularExpenseEntity>
{
    public void Configure(EntityTypeBuilder<RegularExpenseEntity> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.UnitType)
            .WithMany(p => p.RegularExpenses)
            .HasForeignKey(o => o.UnitTypeId);
        
        builder.HasOne(o => o.Project)
            .WithMany(p => p.RegularExpenses)
            .HasForeignKey(o => o.ProjectId);
    }
}