using AutoMapper;
using SuperAppAPI.Models.Domain;
using SuperAppAPI.Models.DTO;

namespace SuperAppAPI.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<OTTDomain, PlatformDTO>().ReverseMap();
            CreateMap<PlatformDTO, OTTDomain>().ReverseMap();
            CreateMap<PayementMethods, PayementDto>().ReverseMap();
            CreateMap<PayementDto,PayementMethods>().ReverseMap();
            CreateMap<PlansDomain, PlansDto>().ReverseMap();
            CreateMap<PlansDto, PlansDomain>().ReverseMap();
            CreateMap<SubUsers, SubUserRequestDTO>().ReverseMap();
            CreateMap<SubUserRequestDTO, SubUsers>().ReverseMap();
            CreateMap<SubscribedPlans, SubscribedPlanDto>().ReverseMap();
            CreateMap<SubscribedPlanDto,SubscribedPlans>().ReverseMap();
            CreateMap<SubUsers, SubUserResponseDTO>().ReverseMap();
        }
    }
}
