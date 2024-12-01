namespace ISCC.Domain.Models;

public class CreateResource
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ProjectPlanId { get; set; }
    public Guid UnitTypeId { get; set; }
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
    
    public CreateResource(string name,Guid unitTypeId,int quantity, decimal surcharge,decimal costPricePerUnitMaterial,decimal costPricePerUnitWork,double laborPerUnit)
    {
        Name = name;
        UnitTypeId = unitTypeId;
        
        Quantity = quantity;
        Surcharge = surcharge;
        
        CostPricePerUnitMaterial = costPricePerUnitMaterial;
        CostPricePerUnitWork = costPricePerUnitWork;
        TotalCostPriceMaterial = CostPricePerUnitMaterial * Quantity;
        TotalCostPriceWork = CostPricePerUnitWork * Quantity;
        TotalCostPrice = TotalCostPriceMaterial + TotalCostPriceWork;
        
        ActualPricePerUnitMaterial = CostPricePerUnitMaterial * Surcharge;
        ActualPricePerUnitWork = CostPricePerUnitWork * Surcharge;
        TotalActualPriceMaterial = ActualPricePerUnitMaterial * Quantity;
        TotalActualPriceWork = ActualPricePerUnitWork * Quantity;

        TotalActualPrice = TotalActualPriceMaterial + TotalActualPriceWork;

        LaborPerUnit = laborPerUnit;
        TotalLabor = LaborPerUnit * Quantity;
    }
}