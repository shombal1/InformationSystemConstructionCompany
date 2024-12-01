using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISCC.Storage.Configuration;

public class OneTimeExpenseConfiguration : IEntityTypeConfiguration<OneTimeExpenseEntity>
{
    public void Configure(EntityTypeBuilder<OneTimeExpenseEntity> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.UnitType)
            .WithMany(p => p.OneTimeExpenses)
            .HasForeignKey(o => o.UnitTypeId);
        
        builder.HasOne(o => o.Project)
            .WithMany(p => p.OneTimeExpenses)
            .HasForeignKey(o => o.ProjectId);
    }
}