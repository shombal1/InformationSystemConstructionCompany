using ISCC.Api.Models.Request;
using ISCC.Api.Models.Response;
using ISCC.Domain.Models;
using ISCC.Domain.UseCase.CreateProjectUseCase;

namespace ISCC.Api.Profile;

public class Profiles : AutoMapper.Profile
{
    public Profiles()
    {
        CreateMap<CreateProjectDto, CreateProjectCommand>();
        CreateMap<CreateProjectPlanDto, CreateProjectPlanCommand>();
        CreateMap<CreateResourceDto, CreateResourceCommand>();


        CreateMap<GetProject, ProjectDto>();
        CreateMap<GetProjectPlan, ProjectPlanDto>()
            .ForMember(dest=>dest.Resorces,opt=>opt.MapFrom(res=>res.Resources));
        CreateMap<GetResource, ResourceDto>();
        CreateMap<GetGroupTask, GroupTasksDto>();
        CreateMap<GetTask, TaskDto>();
    }
}