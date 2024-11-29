using AutoMapper;
using ISCC.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Controllers;

public class ProjectController : ControllerBase
{
    [HttpPost]
    [Route("GetAllProjects")]
    public IActionResult GetAllProjects(
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken)
    {
        Guid projectId = Guid.Parse("C01F6DA0-994B-4527-8800-F39632B148C0");


        var result = new Project
        {
            Id = projectId,
            Name = "Постройка дома",
            StartDate = new DateOnly(2020, 3, 4),
            PlannedEndDate = new DateOnly(2025, 2, 2),
            EndDate = null,
            ProjectPlans =
            [
                new ProjectPlan()
                {
                    Id = Guid.Parse("401B4889-06C6-4BEC-979A-BEFAAC935DB0"),
                    Name = "залить бетон",
                    StartDate = new DateOnly(2021, 1, 1),
                    PlannedEndDate = new DateOnly(2022, 1, 1),
                    EndDate = new DateOnly(2022, 3, 3),
                    ProjectId = projectId
                },
                new ProjectPlan()
                {
                    Id = Guid.Parse("C7937152-3F41-48F4-9EDB-76A886EF660E"),
                    Name = "сад",
                    StartDate = new DateOnly(2022, 5, 5),
                    PlannedEndDate = new DateOnly(2023, 3, 3),
                    EndDate = null,
                    ProjectId = projectId
                },
                new ProjectPlan()
                {
                    Id = Guid.Parse("456BCE3D-C7AA-4561-AFFF-304C92E975F9"),
                    Name = "огород",
                    StartDate = new DateOnly(2022, 7, 7),
                    PlannedEndDate = new DateOnly(2023, 3, 3),
                    EndDate = null,
                    ProjectId = projectId,
                    PreviousPlanId = Guid.Parse("C7937152-3F41-48F4-9EDB-76A886EF660E")
                }
            ]
        };

        return Ok(new[]{result});
    }
    
}