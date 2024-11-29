namespace ISCC.Api.Models.Response;

public class ProjectPlan
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly PlannedEndDate { get; set; }
    public DateOnly? EndDate { get; set; }
    
    public Guid ProjectId { get; set; }
    
    public Guid? PreviousPlanId { get; set; }
}