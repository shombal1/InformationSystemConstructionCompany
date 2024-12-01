using ISCC.Domain.Models;
using MediatR;

namespace ISCC.Domain.UseCase.CreateProjectUseCase;

public record CreateProjectCommand(
    string Name,
    DateOnly StartDate,
    DateOnly PlannedEndDate,
    DateOnly? EndDate,
    List<CreateProjectPlanCommand> ProjectsPlan
) : IRequest<GetProject>;

public record CreateProjectPlanCommand(
    string Name,
    int Quantity,
    DateOnly StartDate,
    DateOnly PlannedEndDate,
    DateOnly? EndDate,
    List<CreateResourceCommand> Resources);

public record CreateResourceCommand(
    Guid UnitTypeId,
    string Name,
    int Quantity,
    decimal Surcharge,
    decimal CostPricePerUnitMaterial,
    decimal CostPricePerUnitWork,
    double LaborPerUnit);