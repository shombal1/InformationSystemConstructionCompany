using ISCC.Domain.Models;
using MediatR;

namespace ISCC.Domain.UseCase.GetAllProjects;

public class GetAllProjectUseCase(IGetAllProjectStorage getAllProjectStorage) : IRequestHandler<GetAllProjectQuery, IEnumerable<GetProject>>
{
    public Task<IEnumerable<GetProject>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
    {
        return getAllProjectStorage.GetAll();
    }
}