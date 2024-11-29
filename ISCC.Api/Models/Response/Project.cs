namespace ISCC.Api.Models.Response;

public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly PlannedEndDate { get; set; }
    public DateOnly? EndDate { get; set; }

    public List<ProjectPlan> ProjectPlans { get; set; } = null!;
}