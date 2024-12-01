using System.ComponentModel.DataAnnotations;

namespace ISCC.Storage.Entities;

public class ProjectPlanEntity
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    public DateOnly StartDate { get; set; }
    public DateOnly PlannedEndDate { get; set; }
    public DateOnly? EndDate { get; set; }
    
    public int Quantity { get; set; }

    public decimal TotalActualPriceMaterial { get; set; }
    public decimal TotalActualPriceWork { get; set; }
    public decimal TotalActualPrice { get; set; }
    public double TotalLabor { get; set; }

    public decimal TotalCostPriceMaterial { get; set; }
    public decimal TotalCostPriceWork { get; set; }
    public decimal TotalCostPrice { get; set; }
    
    public Guid ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
    
    public ICollection<TaskEntity> Tasks { get; set; } = null!;
    
    public ICollection<ResourceEntity> Resources { get; set; } = null!;
}