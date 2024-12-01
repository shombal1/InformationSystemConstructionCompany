using AutoMapper;
using ISCC.Api.Models.Request;
using ISCC.Api.Models.Response;
using ISCC.Domain.UseCase.CreateProjectUseCase;
using ISCC.Domain.UseCase.GetAllProjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Controllers;

public class ProjectController : ControllerBase
{
    [HttpGet]
    [Route("GetAllProjects")]
    public async Task<IActionResult> GetAllProjects(
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        return Ok((await mediator.Send(new GetAllProjectQuery(), cancellationToken)).Select(mapper.Map<ProjectDto>));
    }


    [HttpPost]
    [Route("CreateProject")]
    public async Task<IActionResult> CreateProject(
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator,
        [FromBody] CreateProjectDto createProjectDto,
        CancellationToken cancellationToken)
    {
        return Ok(mapper.Map<ProjectDto>(await mediator.Send(
            mapper.Map<CreateProjectCommand>(createProjectDto), cancellationToken)));
    }
}