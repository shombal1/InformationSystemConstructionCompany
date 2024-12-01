using AutoMapper;
using ISCC.Domain.Models;
using ISCC.Domain.UseCase.CreateProjectUseCase;
using ISCC.Storage.Entities;

namespace ISCC.Storage.Storages;

public class CreateProjectStorage(MainDbContext mainDbContext,IMapper mapper) : ICreateProjectStorage
{
    public async Task<GetProject> Create(CreateProject createProject)
    {
        var result = await mainDbContext.Projects.AddAsync(mapper.Map<ProjectEntity>(createProject));

        await mainDbContext.SaveChangesAsync();
        
        return mapper.Map<GetProject>(result.Entity);
    }
}