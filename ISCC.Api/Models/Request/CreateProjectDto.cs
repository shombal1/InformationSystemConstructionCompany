namespace ISCC.Api.Models.Request;

public record CreateProjectDto(
    string Name,
    DateOnly StartDate,
    DateOnly PlannedEndDate,
    DateOnly? EndDate,
    List<CreateProjectPlanDto> ProjectsPlan
);