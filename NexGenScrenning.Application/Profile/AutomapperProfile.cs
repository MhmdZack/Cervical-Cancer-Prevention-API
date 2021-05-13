using AutoMapper;
using NexGenScreening.Domain;
using NexGenScreening.Application.DTOs.User;
using NexGenScreening.Application.Features.Users.Commands;

namespace NexGenScreening.Application
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.UserStatus, opt => opt.MapFrom(x => x.UserStatuses.StatusValue))
                .ReverseMap();
        }
    }
}
