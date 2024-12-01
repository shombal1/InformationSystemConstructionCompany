using ISCC.Domain.Models;
using MediatR;

namespace ISCC.Domain.UseCase.GetAllProjects;

public record GetAllProjectQuery() : IRequest<IEnumerable<GetProject>>;