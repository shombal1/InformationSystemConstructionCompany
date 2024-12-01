using System.ComponentModel.DataAnnotations;

namespace ISCC.Storage.Entities;

public class ProjectEntity
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly PlannedEndDate { get; set; }
    public DateOnly? EndDate { get; set; }
    
    public decimal TotalActualPriceMaterial { get; set; }
    public decimal TotalActualPriceWork { get; set; }
    public decimal TotalActualPrice { get; set; }

    public decimal TotalCostPriceMaterial { get; set; }
    public decimal TotalCostPriceWork { get; set; }
    public decimal TotalCostPrice { get; set; }
    
    public decimal TotalPriceExpense { get; set; } 
    public double TotalLabor { get; set; }
    
    public ICollection<ProjectPlanEntity> Plans { get; set; } = null!;
    
    public ICollection<GroupTaskEntity> GroupTasks { get; set; } = null!;
    // public ICollection<ResourceEntity> Resources { get; set; } = null!;
    
    public ICollection<RegularExpenseEntity> RegularExpenses { get; set; } = null!;
    public ICollection<OneTimeExpenseEntity> OneTimeExpenses { get; set; } = null!;
}