namespace ISCC.Domain.Models;

public class GetTask
{
    public Guid Id { get; set; }
    public Guid ProjectPlanId { get; set; }
    public string Name { get; set; }

    public decimal PercentageContent { get; set; }
    public int Quantity { get; set; }

    public decimal TotalActualPriceMaterial { get; set; }
    public decimal TotalActualPriceWork { get; set; }
    public decimal TotalActualPrice { get; set; }
    public double TotalLabor { get; set; }

    public decimal TotalCostPriceMaterial { get; set; }
    public decimal TotalCostPriceWork { get; set; }
    public decimal TotalCostPrice { get; set; }
    
    
}