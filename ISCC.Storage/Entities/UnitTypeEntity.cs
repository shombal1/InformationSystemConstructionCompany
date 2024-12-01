using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ISCC.Storage.Entities;

public class UnitTypeEntity
{
    public Guid Id { get; set; }
    [MaxLength(5)] public string Name { get; set; } = "";

    public ICollection<ResourceEntity> Resources = null!;
    public ICollection<RegularExpenseEntity> RegularExpenses { get; set; } = null!;
    public ICollection<OneTimeExpenseEntity> OneTimeExpenses { get; set; } = null!;
}