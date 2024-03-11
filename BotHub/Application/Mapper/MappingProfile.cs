using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities.Identity;

namespace Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserViewModel, User>();
        CreateMap<UpdateUserViewModel, User>();
    }
}