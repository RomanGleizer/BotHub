using Application.Interfaces;
using Application.ViewModels.CommentViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

/// <summary>
/// Сервис для управления комментариями.
/// </summary>
/// <remarks>
/// Инициализирует новый экземпляр класса CommentService.
/// </remarks>
/// <param name="userRepository">Репозиторий пользователей.</param>
/// <param name="commentRepository">Репозиторий комментариев.</param>
/// <param name="commentRepository">Репозиторий постов.</param>
/// <param name="mapper">Маппер для преобразования между сущностями и моделями представления.</param>
public class CommentService(
    IUserRepository userRepository,
    IRepository<Comment, Guid> commentRepository, 
    IRepository<Post, Guid> postRepository,  
    IMapper mapper) 
    : ICommentService
{
    /// <inheritdoc/>
    public async Task<IList<CommentViewModel>> GetAllAsync()
    {
        var comments = await commentRepository.GetAllAsync();
        return mapper.Map<IList<CommentViewModel>>(comments);
    }

    /// <inheritdoc/>
    public async Task<CommentViewModel> GetByIdAsync(Guid id)
    {
        var existingComment = await commentRepository.GetByIdAsync(id)
            ?? throw new Exception("Не удалось найти комментарий БД");

        return mapper.Map<CommentViewModel>(existingComment);
    }

    /// <inheritdoc/>
    public async Task<CommentViewModel> CreateAsync(CreateCommentViewModel comment)
    {
        var mappedComment = mapper.Map<Comment>(comment);
        
        var createdComment = await commentRepository.CreateAsync(mappedComment)
            ?? throw new Exception("Произошла ошибка при добавлении комментария в БД");

        var post = await postRepository.GetByIdAsync(createdComment.PostId)
            ?? throw new Exception("Произошла ошибка при добавлении комментария в БД");
        
        var author = await userRepository.GetByIdAsync(createdComment.AuthorId)
            ?? throw new Exception("Не удалось найти пользователя БД");
        
        post.CommentIds.Add(createdComment.Id);
        author.CommentIds.Add(createdComment.Id);
        
        await postRepository.UpdateAsync(post);
        await userRepository.UpdateAsync(author);
        
        return mapper.Map<CommentViewModel>(createdComment);
    }

    /// <inheritdoc/>
    public async Task<CommentViewModel> DeleteAsync(Guid id)
    {
        var existingComment = await commentRepository.GetByIdAsync(id)
            ?? throw new Exception("Не удалось найти комментарий БД");

        var mappedComment = mapper.Map<Comment>(existingComment);
        
        var deletedComment = await commentRepository.DeleteAsync(mappedComment)
            ?? throw new Exception("Произошла ошибка при добавлении пользователя из БД");

        var post = await postRepository.GetByIdAsync(deletedComment.PostId) 
            ?? throw new Exception("Произошла ошибка при добавлении комментария в БД");
        
        var author = await userRepository.GetByIdAsync(deletedComment.AuthorId) 
            ?? throw new Exception("Не удалось найти пользователя БД");
        
        post.CommentIds.Remove(deletedComment.Id);
        author.CommentIds.Remove(deletedComment.Id);
        
        await postRepository.UpdateAsync(post);
        await userRepository.UpdateAsync(author);
        
        return mapper.Map<CommentViewModel>(deletedComment);
    }

    /// <inheritdoc/>
    public async Task<CommentViewModel> UpdateAsync(Guid id, UpdateCommentViewModel comment)
    {
        var existingComment = await commentRepository.GetByIdAsync(id)
            ?? throw new Exception("Не удалось найти комментарий БД");

        existingComment = existingComment with
        {
            Id = id,
            Text = comment.Text,
            LikesAmount = comment.LikesAmount,
            DislikesAmount = comment.DislikesAmount
        };

        var updatedComment = await commentRepository.UpdateAsync(existingComment)
            ?? throw new Exception("Произошла ошибка при обнволении пользователя в БД");

        return mapper.Map<CommentViewModel>(updatedComment);
    }
}
