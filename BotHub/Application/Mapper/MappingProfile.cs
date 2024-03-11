using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserViewModel, User>();
        CreateMap<UpdateUserViewModel, User>();
        CreateMap<User, UserViewModel>();
    }
}