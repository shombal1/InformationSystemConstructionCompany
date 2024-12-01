using AutoMapper;
using AutoMapper.QueryableExtensions;
using ISCC.Domain.Models;
using ISCC.Domain.UseCase.GetAllProjects;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Storage.Storages;

public class GetProjectStorage(MainDbContext dbContext, IMapper mapper) : IGetProjectStorage
{
    public Task<GetProject> Get(Guid projectId)
    {
        return dbContext.Projects.Where(p => p.Id == projectId)
            .ProjectTo<GetProject>(mapper.ConfigurationProvider).FirstAsync();
    }
}