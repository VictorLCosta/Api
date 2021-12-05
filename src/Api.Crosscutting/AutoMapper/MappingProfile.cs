using Api.Domain.DTO.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Crosscutting.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>()
                .ReverseMap();

            CreateMap<CreateUserResultDto, User>()
                .ReverseMap();

            CreateMap<UpdateUserResultDto, User>()
                .ReverseMap();

            
        }
    }
}