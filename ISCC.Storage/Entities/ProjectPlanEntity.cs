namespace ISCC.Storage.Entities;

public class ProjectPlanEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset CreatedDate { get; set; }
    
    public Guid ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
    
    public Guid? PreviousPlanId { get; set; }
    public ProjectPlanEntity? PreviousPlan { get; set; }
    
    //public ICollection<Task> Tasks { get; set; } = null!;
}