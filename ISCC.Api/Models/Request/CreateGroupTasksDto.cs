namespace ISCC.Api.Models.Request;

public record CreateGroupTasksDto(
    string Name,
    Guid ProjectId,
    List<CreateTaskDto> Tasks,
    List<CreateGroupTasksDto> SubGroups
);