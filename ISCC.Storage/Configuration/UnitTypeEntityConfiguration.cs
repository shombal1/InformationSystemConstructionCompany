using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISCC.Storage.Configuration;

public class UnitTypeEntityConfiguration : IEntityTypeConfiguration<UnitTypeEntity>
{
    public void Configure(EntityTypeBuilder<UnitTypeEntity> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.HasMany(p => p.Resources)
            .WithOne(p => p.UnitType);
        
        builder.HasMany(p => p.OneTimeExpenses)
            .WithOne(p => p.UnitType);
        
        builder.HasMany(p => p.RegularExpenses)
            .WithOne(p => p.UnitType);
    }
}