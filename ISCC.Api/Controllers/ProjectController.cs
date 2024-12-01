using AutoMapper;
using ISCC.Api.Models.Request;
using ISCC.Api.Models.Response;
using ISCC.Domain.UseCase.CreateProjectUseCase;
using ISCC.Domain.UseCase.GetAllProjects;
using ISCC.Storage;
using ISCC.Storage.Entities;
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

    
    [HttpPost]
    [Route("CreateGroup")]
    public async Task<IActionResult> CreateGroup([FromServices] MainDbContext dbContext,[FromBody] IEnumerable<CreateGroupTasksDto> groups )
    {
        return Ok(await Task.FromResult("sucess"));
    }
    
    // public async Task AddGroupsAsync(MainDbContext dbContext,IEnumerable<CreateGroupTasksDto> groupTasks)
    // {
    //     foreach (var group in groupTasks)
    //     {
    //         await AddGroupAsync(group);
    //     }
    //     await dbContext.SaveChangesAsync();
    // }
    //
    // private async Task AddGroupAsync(MainDbContext dbContext,CreateGroupTasksDto group)
    // {
    //     var groupEntity = new GroupTaskEntity()
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = group.Name,
    //         ProjectId = group.ProjectId,
    //         
    //         
    //     };
    //     await dbContext.GroupTasks.AddAsync(groupEntity);
    //
    //
    //     foreach (var task in group.Tasks)
    //     {
    //         var plan = dbContext.ProjectPlans.First(p => task. == p.Id);
    //         
    //         var taskEntity = new TaskEntity
    //         {
    //             Id = Guid.NewGuid(),
    //             Name = task.Name,
    //             Quantity = task.Quantity,
    //             GroupId = groupEntity.Id,
    //             ProjectPlanId = plan.Id
    //         };
    //         await dbContext.Tasks.AddAsync(taskEntity);
    //     }
    //     
    //     foreach (var subGroup in group.SubGroups)
    //     {
    //         await AddGroupAsync(dbContext,subGroup);
    //     }
    // }
}