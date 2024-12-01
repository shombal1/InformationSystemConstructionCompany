namespace ISCC.Api.Models.Response;

public class GroupTasksDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public GroupTasksDto? ParentGroup { get; set; }

    public ICollection<TaskDto> Tasks { get; set; } = null!;
}