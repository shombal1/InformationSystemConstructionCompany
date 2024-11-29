namespace ISCC.Storage.Entities;

public class ProjectEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset PlannedEndDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    
    public ICollection<ProjectPlanEntity> Plans { get; set; } = null!;
}