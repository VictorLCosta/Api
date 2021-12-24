using Api.Domain.DTO.User;
using Api.Domain.DTO.Cep;
using Api.Domain.DTO.City;
using Api.Domain.DTO.State;
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


            CreateMap<CityDto, City>()
                .ReverseMap();

            CreateMap<CreateCityDto, City>()
                .ReverseMap();

            CreateMap<UpdateCityDto, City>()
                .ReverseMap();

            CreateMap<CreateCityResultDto, City>()
                .ReverseMap();

            CreateMap<UpdateCityResultDto, City>()
                .ReverseMap();


            CreateMap<CepDto, Cep>()
                .ReverseMap();

            CreateMap<CreateCepDto, Cep>()
                .ReverseMap();

            CreateMap<UpdateCepDto, Cep>()
                .ReverseMap();

            CreateMap<CreateCepResultDto, Cep>()
                .ReverseMap();

            CreateMap<UpdateCepResultDto, Cep>()
                .ReverseMap();

            
            CreateMap<StateDto, State>()
                .ReverseMap();

        }
    }
}