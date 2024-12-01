using ISCC.Domain.Models;

namespace ISCC.Domain.UseCase.GetAllProjects;

public interface IGetAllProjectStorage
{
    public Task<IEnumerable<GetProject>> GetAll();
}