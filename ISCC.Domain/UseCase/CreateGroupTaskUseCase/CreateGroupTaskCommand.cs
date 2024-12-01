using ISCC.Domain.Models;
using MediatR;

namespace ISCC.Domain.UseCase.CreateGroupTaskUseCase;

public record CreateRangeGroupTaskCommand(IEnumerable<CreateGroupTaskCommand> Groups): IRequest<GetProject>;

public record CreateGroupTaskCommand(
    string Name,
    Guid ProjectId,
    List<CreateTaskCommand> Tasks,
    List<CreateGroupTaskCommand> SubGroups
);

public record CreateTaskCommand(string Name, int Quantity);