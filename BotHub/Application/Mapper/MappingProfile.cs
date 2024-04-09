using Application.ViewModels.CommentViewModels;
using Application.ViewModels.PostViewModels;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterViewModel, User>();
        CreateMap<UpdateUserViewModel, User>();
        CreateMap<User, UserViewModel>();

        CreateMap<CreatePostViewModel, Post>();
        CreateMap<UpdatePostViewModel, Post>();
        CreateMap<Post, PostViewModel>();

        CreateMap<CreateCommentViewModel, Comment>();
        CreateMap<UpdatePostViewModel, Comment>();
        CreateMap<Comment, CommentViewModel>();
    }
}