namespace ISCC.Domain.Models;

public class CreateProjectPlan
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    
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

    public CreateProjectPlan(string name,DateOnly startDate,DateOnly plannedEndDate,DateOnly? endDate,int quantity,List<CreateResource> resource)
    {
        Name = name;
        StartDate = startDate;
        PlannedEndDate = plannedEndDate;
        EndDate = endDate;
        Quantity = quantity;
        
        TotalActualPriceMaterial = resource.Sum(r => r.TotalActualPriceMaterial);
        TotalActualPriceWork = resource.Sum(r => r.TotalActualPriceWork);
        TotalActualPrice = TotalActualPriceMaterial + TotalActualPriceWork;

        TotalCostPriceMaterial = resource.Sum(r => r.TotalCostPriceMaterial);
        TotalCostPriceWork = resource.Sum(r => r.TotalCostPriceWork);
        TotalCostPrice = TotalCostPriceMaterial + TotalCostPriceWork;
        
        TotalLabor = resource.Sum(r => r.TotalLabor);
        
    }
}