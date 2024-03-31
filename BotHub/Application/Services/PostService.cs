using Application.Interfaces;
using Application.ViewModels.PostViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

/// <summary>
/// Сервис для управления постами.
/// </summary>
/// <remarks>
/// Инициализирует новый экземпляр класса PostService.
/// </remarks>
/// <param name="repository">Репозиторий постов.</param>
/// <param name="mapper">Маппер для преобразования между сущностями и моделями представления.</param>
public class PostService(IRepository<Post, Guid> repository, IMapper mapper) : IPostService
{
    private readonly IRepository<Post, Guid> _repository = repository;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc/>
    public async Task<IList<PostViewModel>> GetAllAsync()
    {
        var allPosts = await _repository.GetAllAsync();
        return _mapper.Map<IList<PostViewModel>>(allPosts);
    }

    /// <inheritdoc/>
    public async Task<PostViewModel> GetByIdAsync(Guid id)
    {
        var existingPost = await _repository.GetByIdAsync(id) 
            ?? throw new Exception("Не удалось найти пост БД");

        return _mapper.Map<PostViewModel>(existingPost);
    }

    /// <inheritdoc/>
    public async Task<PostViewModel> CreateAsync(CreatePostViewModel post)
    {
        var mappedPost = _mapper.Map<Post>(post);
        var createdPost = await _repository.CreateAsync(mappedPost)
            ?? throw new Exception("Произошла ошибка при добавлении поста в БД");

        return _mapper.Map<PostViewModel>(createdPost);
    }

    /// <inheritdoc/>
    public async Task<PostViewModel> DeleteAsync(Guid id)
    {
        var existingPost = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Не удалось найти пост БД");

        var deletedPost = await _repository.DeleteAsync(existingPost)
            ?? throw new Exception("Произошла ошибка при удалении поста из БД");

        return _mapper.Map<PostViewModel>(deletedPost);
    }

    /// <inheritdoc/>
    public async Task<PostViewModel> UpdateAsync(Guid id, UpdatePostViewModel post)
    {
        var existingPost = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Не удалось найти пост БД");

        existingPost = existingPost with
        {
            Id = id,
            Title = post.Title,
            ShortDescription = post.ShortDescription,
            FullDescription = post.FullDescription,
            BotСapabilities = post.BotСapabilities,
            BotLink = post.BotLink,
            BotImage = post.BotImage
        };

        var updatedPost = await _repository.UpdateAsync(existingPost)
            ?? throw new Exception("Произошла ошибка при обновлении поста в БД");

        return _mapper.Map<PostViewModel>(updatedPost);
    }
}
