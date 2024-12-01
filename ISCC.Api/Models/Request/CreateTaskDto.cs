namespace ISCC.Api.Models.Request;

public record CreateTaskDto(string Name, int Quantity,Guid PlanId);