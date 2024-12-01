using ISCC.Domain.Models;

namespace ISCC.Domain.UseCase.GetAllProjects;

public interface IGetProjectStorage : IStorage
{
    public Task<GetProject> Get(Guid projectId);
}