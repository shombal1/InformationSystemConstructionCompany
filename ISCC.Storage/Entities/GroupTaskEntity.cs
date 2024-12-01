using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ISCC.Storage.Entities;

public class GroupTaskEntity
{
    public Guid Id { get; set; }

    [MaxLength(100)] public string Name { get; set; }

    public Guid ProjectId { get; set; }
    public ProjectEntity Project { get; set; }
    
    public Guid? ParentGroupId { get; set; }
    public GroupTaskEntity? ParentGroup { get; set; } = null!;
    
    public ICollection<TaskEntity> Tasks { get; set; } = null!;

    public ICollection<GroupTaskEntity> SubGroups { get; set; } = null!;
}