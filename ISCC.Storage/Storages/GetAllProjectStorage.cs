using AutoMapper;
using AutoMapper.QueryableExtensions;
using ISCC.Domain.Models;
using ISCC.Domain.UseCase.GetAllProjects;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Storage.Storages;

public class GetAllProjectStorage(MainDbContext dbContext, IMapper mapper) : IGetAllProjectStorage
{
    public async Task<IEnumerable<GetProject>> GetAll()
    {
        return await dbContext.Projects.ProjectTo<GetProject>(mapper.ConfigurationProvider).ToArrayAsync();
    }
}