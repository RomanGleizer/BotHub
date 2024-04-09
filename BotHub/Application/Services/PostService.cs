using Application.Interfaces;
using Application.ViewModels.PostViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

/// <summary>
///     Сервис для управления постами.
/// </summary>
/// <remarks>
///     Инициализирует новый экземпляр класса PostService.
/// </remarks>
/// <param name="postRepository">Репозиторий постов.</param>
/// <param name="userRepository">Репозиторий пользователей.</param>
/// <param name="mapper">Маппер для преобразования между сущностями и моделями представления.</param>
public class PostService(
    IRepository<Post, Guid> postRepository,
    IUserRepository userRepository,
    IMapper mapper)
    : IPostService
{
    /// <inheritdoc />
    public async Task<IList<PostViewModel>> GetAllAsync()
    {
        var allPosts = await postRepository.GetAllAsync();
        return mapper.Map<IList<PostViewModel>>(allPosts);
    }

    /// <inheritdoc />
    public async Task<PostViewModel> GetByIdAsync(Guid id)
    {
        var existingPost = await postRepository.GetByIdAsync(id)
                           ?? throw new Exception("Не удалось найти пост БД");

        return mapper.Map<PostViewModel>(existingPost);
    }

    /// <inheritdoc />
    public async Task<PostViewModel> CreateAsync(CreatePostViewModel post)
    {
        var mappedPost = mapper.Map<Post>(post);
        var createdPost = await postRepository.CreateAsync(mappedPost)
                          ?? throw new Exception("Произошла ошибка при добавлении поста в БД");

        var author = await userRepository.GetByIdAsync(createdPost.AuthorId)
                     ?? throw new Exception("Не удалось найти пользователя БД");

        author.PostIds.Add(createdPost.Id);
        await userRepository.UpdateAsync(author);

        return mapper.Map<PostViewModel>(createdPost);
    }

    /// <inheritdoc />
    public async Task<PostViewModel> DeleteAsync(Guid id)
    {
        var existingPost = await postRepository.GetByIdAsync(id)
                           ?? throw new Exception("Не удалось найти пост БД");

        var deletedPost = await postRepository.DeleteAsync(existingPost)
                          ?? throw new Exception("Произошла ошибка при удалении поста из БД");

        var author = await userRepository.GetByIdAsync(deletedPost.AuthorId)
                     ?? throw new Exception("Не удалось найти пользователя БД");

        author.PostIds.Remove(deletedPost.Id);
        await userRepository.UpdateAsync(author);

        return mapper.Map<PostViewModel>(deletedPost);
    }

    /// <inheritdoc />
    public async Task<PostViewModel> UpdateAsync(Guid id, UpdatePostViewModel post)
    {
        var existingPost = await postRepository.GetByIdAsync(id)
                           ?? throw new Exception("Не удалось найти пост БД");

        existingPost = existingPost with
        {
            Id = id,
            Title = post.Title,
            ShortDescription = post.ShortDescription,
            FullDescription = post.FullDescription,
            BotPossibilities = post.BotPossibilities,
            BotLink = post.BotLink,
            BotImage = post.BotImage
        };

        var updatedPost = await postRepository.UpdateAsync(existingPost)
                          ?? throw new Exception("Произошла ошибка при обновлении поста в БД");

        return mapper.Map<PostViewModel>(updatedPost);
    }
}