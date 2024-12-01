namespace ISCC.Domain.Models;

public class GetProject
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
    
    public ICollection<GetProjectPlan> Plans { get; set; } = null!;
    
    public ICollection<GetGroupTask> GroupTasks { get; set; } = null!;
    
    public ICollection<GetRegularExpense> RegularExpenses { get; set; } = null!;
    public ICollection<GetOneTimeExpense> OneTimeExpenses { get; set; } = null!;
}