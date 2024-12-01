using System.ComponentModel.DataAnnotations;

namespace ISCC.Storage.Entities;

public class RegularExpenseEntity
{
    public Guid Id { get; set; }
    
    [MaxLength(100)] public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerUnit { get; set; }
    public decimal TotalPrice { get; set; }
    public double DurationInMonths { get; set; }
    
    public Guid UnitTypeId { get; set; }
    public UnitTypeEntity UnitType { get; set; } = null!;
    
    public Guid ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
}