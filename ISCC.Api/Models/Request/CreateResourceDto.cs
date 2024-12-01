namespace ISCC.Api.Models.Request;

public record CreateResourceDto(
    Guid UnitTypeId,
    string Name,
    int Quantity,
    decimal Surcharge,
    decimal CostPricePerUnitMaterial,
    decimal CostPricePerUnitWork,
    double LaborPerUnit);