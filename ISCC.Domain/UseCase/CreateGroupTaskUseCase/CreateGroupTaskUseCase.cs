using ISCC.Domain.Models;
using MediatR;

namespace ISCC.Domain.UseCase.CreateGroupTaskUseCase;

public class CreateGroupTaskUseCase(IUnitOfWork unitOfWork) : IRequestHandler<CreateRangeGroupTaskCommand, GetProject>
{
    public Task<GetProject> Handle(CreateRangeGroupTaskCommand request, CancellationToken cancellationToken)
    {
        foreach (var group in request.Groups)
        {
            
        }

        return null;
    }
}