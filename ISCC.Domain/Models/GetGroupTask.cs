namespace ISCC.Domain.Models;

public class GetGroupTask
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public GetGroupTask? ParentGroup { get; set; }

    public ICollection<GetTask> Tasks { get; set; } = null!;
}