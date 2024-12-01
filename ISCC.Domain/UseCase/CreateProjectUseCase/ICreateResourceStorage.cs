using ISCC.Domain.Models;

namespace ISCC.Domain.UseCase.CreateProjectUseCase;

public interface ICreateResourceStorage : IStorage
{
    public Task Create(List<CreateResource> resources);
}