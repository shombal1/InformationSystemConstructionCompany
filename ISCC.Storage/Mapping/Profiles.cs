using AutoMapper;
using ISCC.Domain.Models;
using ISCC.Storage.Entities;

namespace ISCC.Storage.Mapping;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<GroupTaskEntity, GetGroupTask>();
        CreateMap<ProjectPlanEntity, GetProjectPlan>();
        CreateMap<ProjectEntity, GetProject>();
        CreateMap<ResourceEntity, GetResource>()
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(res => res.UnitType.Name));
        CreateMap<TaskEntity, GetTask>();
        CreateMap<UnitTypeEntity, UnitType>();
        CreateMap<OneTimeExpenseEntity, GetOneTimeExpense>();
        CreateMap<RegularExpenseEntity, GetRegularExpense>();


        CreateMap<CreateProject, ProjectEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            //.ForMember(dest => dest.Resources, opt => opt.Ignore())
            .ForMember(dest => dest.Plans, opt => opt.Ignore())
            .ForMember(dest => dest.GroupTasks, opt => opt.Ignore())
            .ForMember(dest => dest.OneTimeExpenses, opt => opt.Ignore())
            .ForMember(dest => dest.RegularExpenses, opt => opt.Ignore());

        CreateMap<CreateProjectPlan, ProjectPlanEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Project, opt => opt.Ignore())
            .ForMember(dest => dest.Tasks, opt => opt.Ignore())
            .ForMember(dest => dest.Resources, opt => opt.Ignore());

        CreateMap<CreateResource, ResourceEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UnitType, opt => opt.Ignore())
            .ForMember(dest => dest.ProjectPlan, opt => opt.Ignore());
        //.ForMember(dest => dest.Project, opt => opt.Ignore());
    }
}