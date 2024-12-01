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
        await AddGroupsAsync(dbContext,groups);
        await dbContext.SaveChangesAsync();
        return Ok(await Task.FromResult("sucess"));
    }
    
    public async Task AddGroupsAsync(MainDbContext dbContext,IEnumerable<CreateGroupTasksDto> groupTasks)
    {
        foreach (var group in groupTasks)
        {
            await AddGroupAsync(null,dbContext,group);
        }
        await dbContext.SaveChangesAsync();
    }
    
    
    
    private async Task AddGroupAsync(Guid? parentGroupId,MainDbContext dbContext,CreateGroupTasksDto group)
    {
        
    // public Guid Id { get; set; }
    //
    // [MaxLength(100)] public string Name { get; set; }
    //
    // public Guid ProjectId { get; set; }
    // public ProjectEntity Project { get; set; }
    //
    // public Guid? ParentGroupId { get; set; }
    // public GroupTaskEntity? ParentGroup { get; set; } = null!;
    //
    // public ICollection<TaskEntity> Tasks { get; set; } = null!;
    //
    // public ICollection<GroupTaskEntity> SubGroups { get; set; } = null!;
    
        var groupEntity = new GroupTaskEntity()
        {
            Id = Guid.NewGuid(),
            Name = group.Name,
            ProjectId = group.ProjectId,
            ParentGroupId = parentGroupId
            
        };
        await dbContext.GroupTasks.AddAsync(groupEntity);
    
    
        foreach (var task in group.Tasks)
        {
            var plan = dbContext.ProjectPlans.First(p => task.PlanId == p.Id);
            
            // public class TaskEntity
            // {
            //     public Guid Id { get; set; }
            //     [MaxLength(100)] public string Name { get; set; }
            //
            //     public decimal PercentageContent { get; set; }
            //     public int Quantity { get; set; }
            //
            //     public decimal TotalActualPriceMaterial { get; set; }
            //     public decimal TotalActualPriceWork { get; set; }
            //     public decimal TotalActualPrice { get; set; }
            //     public double TotalLabor { get; set; }
            //
            //     public decimal TotalCostPriceMaterial { get; set; }
            //     public decimal TotalCostPriceWork { get; set; }
            //     public decimal TotalCostPrice { get; set; }
            //
            //     public Guid ProjectPlanId { get; set; }
            //     public ProjectPlanEntity ProjectPlan { get; set; } = null!;
            //
            //     public Guid GroupId { get; set; }
            //     public GroupTaskEntity GroupTask { get; set; }
            // }
            decimal percentageContent = (decimal)task.Quantity/plan.Quantity + 1m;
            var taskEntity = new TaskEntity
            {
                Id = Guid.NewGuid(),
                Name = task.Name,
                Quantity = task.Quantity,
                GroupId = groupEntity.Id,
                ProjectPlanId = plan.Id,
                PercentageContent = percentageContent,
                TotalActualPriceMaterial = plan.TotalActualPriceMaterial * percentageContent,
                TotalActualPriceWork = plan.TotalActualPriceWork * percentageContent,
                TotalActualPrice = plan.TotalActualPrice  * percentageContent,
                TotalLabor = plan.TotalLabor * (double)percentageContent,
                TotalCostPriceMaterial = plan.TotalCostPriceMaterial * percentageContent,
                TotalCostPriceWork = plan.TotalCostPriceWork * percentageContent,
                TotalCostPrice = plan.TotalCostPrice * percentageContent
            };
            await dbContext.Tasks.AddAsync(taskEntity);
        }
        
        foreach (var subGroup in group.SubGroups)
        {
            await AddGroupAsync(groupEntity.ParentGroupId,dbContext,subGroup);
        }
    }
}