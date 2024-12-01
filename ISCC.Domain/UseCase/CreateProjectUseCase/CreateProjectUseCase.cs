using ISCC.Domain.Models;
using ISCC.Domain.UseCase.GetAllProjects;
using MediatR;

namespace ISCC.Domain.UseCase.CreateProjectUseCase;

public class CreateProjectUseCase(IUnitOfWork unitOfWork, IGetProjectStorage getStorage)
    : IRequestHandler<CreateProjectCommand, GetProject>
{
    public async Task<GetProject> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var scope = await unitOfWork.StartScope(cancellationToken);

        var createProjectStorage = scope.GetStorage<ICreateProjectStorage>();
        var createProjectPlanStorage = scope.GetStorage<ICreateProjectPlanStorage>();
        var createResource = scope.GetStorage<ICreateResourceStorage>();

        List<(CreateProjectPlan plan, List<CreateResource> resources)> domainPlans = [];

        foreach (var plan in request.ProjectsPlan)
        {
            var domainResources = plan.Resources.Select(r =>
                    new CreateResource(
                        r.Name,
                        r.UnitTypeId,
                        r.Quantity,
                        r.Surcharge,
                        r.CostPricePerUnitMaterial,
                        r.CostPricePerUnitWork,
                        r.LaborPerUnit))
                .ToList();

            var domainPlan = new CreateProjectPlan(plan.Name, plan.StartDate, plan.PlannedEndDate, plan.EndDate,
                plan.Quantity,
                domainResources);

            domainPlans.Add((domainPlan, domainResources));
        }

        var domainProject = new CreateProject(
            request.Name,
            request.StartDate,
            request.PlannedEndDate,
            request.EndDate,
            domainPlans.Select(p => p.plan).ToList());

        var createdProject = await createProjectStorage.Create(domainProject);

        foreach (var (plan, resources) in domainPlans)
        {
            plan.ProjectId = createdProject.Id;
            var createProjectPlan = await createProjectPlanStorage.Create(plan);

            foreach (var resource in resources)
            {
                resource.ProjectPlanId = createProjectPlan.Id;
            }

            await createResource.Create(resources);
        }
        
        await scope.Commit(cancellationToken);
        await scope.DisposeAsync();

        return await getStorage.Get(createdProject.Id);
    }
}