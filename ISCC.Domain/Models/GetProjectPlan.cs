namespace ISCC.Domain.Models;

public class GetProjectPlan
{
    public Guid Id { get; set; }
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
    
    public ICollection<GetResource> Resources { get; set; } = null!;
}