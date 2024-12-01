using AutoMapper;
using ISCC.Domain.Models;
using ISCC.Domain.UseCase.CreateProjectUseCase;
using ISCC.Storage.Entities;

namespace ISCC.Storage.Storages;

public class CreateResourceStorage(MainDbContext mainDbContext, IMapper mapper) : ICreateResourceStorage
{
    public async Task Create(List<CreateResource> resources)
    {
        await mainDbContext.Resources.AddRangeAsync(resources.Select(mapper.Map<ResourceEntity>));

        await mainDbContext.SaveChangesAsync();
    }
}