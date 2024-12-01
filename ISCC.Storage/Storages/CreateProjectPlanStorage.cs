using AutoMapper;
using ISCC.Domain.Models;
using ISCC.Domain.UseCase.CreateProjectUseCase;
using ISCC.Storage.Entities;

namespace ISCC.Storage.Storages;

public class CreateProjectPlanStorage(MainDbContext mainDbContext,IMapper mapper) : ICreateProjectPlanStorage
{
    public async Task<GetProjectPlan> Create(CreateProjectPlan projectPlan)
    {
        var result = await mainDbContext.ProjectPlans.AddAsync(mapper.Map<ProjectPlanEntity>(projectPlan));

        await mainDbContext.SaveChangesAsync();
        
        return mapper.Map<GetProjectPlan>(result.Entity); 
    }
}