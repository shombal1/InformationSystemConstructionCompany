namespace ISCC.Api.Models.Response;

public class ResourceDto
{
    public Guid Id { get; set; }
    public Guid ProjectPlanId { get; set; }
    public Guid UnitTypeId { get; set; }
    public string UnitName { get; set; }
    
    public string Name { get; set; }

    public int Quantity { get; set; }
    public decimal Surcharge { get; set; }

    public decimal CostPricePerUnitMaterial { get; set; }
    public decimal CostPricePerUnitWork { get; set; }
    public decimal TotalCostPriceMaterial { get; set; }
    public decimal TotalCostPriceWork { get; set; }
    public decimal TotalCostPrice { get; set; }

    public decimal ActualPricePerUnitMaterial { get; set; }
    public decimal ActualPricePerUnitWork { get; set; }
    public decimal TotalActualPriceMaterial { get; set; }
    public decimal TotalActualPriceWork { get; set; }
    public decimal TotalActualPrice { get; set; }
    
    public double LaborPerUnit { get; set; }
    public double TotalLabor { get; set; }
}