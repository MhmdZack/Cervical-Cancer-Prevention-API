using AutoMapper;
using NexGenScreening.Application.DTOs;
using NexGenScreening.Application.Features.Commands;
using NexGenScreening.Domain;

namespace NexGenScreening.Application
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            #region "Command and Entity Mappings"
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<CreateHealthcareCenterCommand, HealthcareCenter>();
            CreateMap<CreateGynaCenterCommand, GynaCenter>();
            #endregion

            #region"Entity and Model Mapper"
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.UserStatus, opt => opt.MapFrom(x => x.UserStatuses.StatusValue))
                .ReverseMap();
            CreateMap<HealthcareCenter, HealthcareCenterViewModel>().ReverseMap();
            CreateMap<GynaCenter, GynaCenterViewModel>();
            #endregion
        }
    }
}
