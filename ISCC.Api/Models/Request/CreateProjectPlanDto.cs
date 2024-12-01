namespace ISCC.Api.Models.Request;

public record CreateProjectPlanDto(
    string Name,
    int Quantity,
    DateOnly StartDate,
    DateOnly PlannedEndDate,
    DateOnly? EndDate,
    List<CreateResourceDto> Resources);