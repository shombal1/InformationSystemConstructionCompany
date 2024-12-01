

namespace ISCC.Api.Models.Response;

public class ProjectDto
{
    public Guid Id { get; set; }
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
    
    public ICollection<ProjectPlanDto> Plans { get; set; } = null!;
    public ICollection<GroupTasksDto> GroupTasks { get; set; } = null!;
}