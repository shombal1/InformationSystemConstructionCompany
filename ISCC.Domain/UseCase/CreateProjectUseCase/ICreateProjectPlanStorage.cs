using ISCC.Domain.Models;

namespace ISCC.Domain.UseCase.CreateProjectUseCase;

public interface ICreateProjectPlanStorage : IStorage
{
    public Task<GetProjectPlan> Create(CreateProjectPlan projectPlan);
}