using ISCC.Domain.Models;

namespace ISCC.Domain.UseCase.CreateProjectUseCase;

public interface ICreateProjectStorage : IStorage
{
    public Task<GetProject> Create(Models.CreateProject createProject);
}