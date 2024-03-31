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
/// <param name="repository">Репозиторий комментариев.</param>
/// <param name="mapper">Маппер для преобразования между сущностями и моделями представления.</param>
public class CommentService(IRepository<Comment, Guid> repository, IMapper mapper) : ICommentService
{
    private readonly IRepository<Comment, Guid> _repository = repository;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc/>
    public async Task<IList<CommentViewModel>> GetAllAsync()
    {
        var comments = await _repository.GetAllAsync();
        return _mapper.Map<IList<CommentViewModel>>(comments);
    }

    /// <inheritdoc/>
    public async Task<CommentViewModel> GetByIdAsync(Guid id)
    {
        var existingComment = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Не удалось найти комментарий БД");

        return _mapper.Map<CommentViewModel>(existingComment);
    }

    /// <inheritdoc/>
    public async Task<CommentViewModel> CreateAsync(CreateCommentViewModel post)
    {
        var mappedComment = _mapper.Map<Comment>(post);
        var createdComment = await _repository.CreateAsync(mappedComment)
            ?? throw new Exception("Произошла ошибка при добавлении комментария в БД");

        return _mapper.Map<CommentViewModel>(createdComment);
    }

    /// <inheritdoc/>
    public async Task<CommentViewModel> DeleteAsync(Guid id)
    {
        var existingComment = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Не удалось найти комментарий БД");

        var mappedComment = _mapper.Map<Comment>(existingComment);

        var deletedComment = await _repository.DeleteAsync(mappedComment)
            ?? throw new Exception("Произошла ошибка при добавлении пользователя из БД");

        return _mapper.Map<CommentViewModel>(deletedComment);
    }

    /// <inheritdoc/>
    public async Task<CommentViewModel> UpdateAsync(Guid id, UpdateCommentViewModel comment)
    {
        var existingComment = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Не удалось найти комментарий БД");

        existingComment = existingComment with
        {
            Id = id,
            Text = comment.Text,
            LikesAmount = comment.LikesAmount,
            DislikesAmount = comment.DislikesAmount
        };

        var updatedComment = await _repository.UpdateAsync(existingComment)
            ?? throw new Exception("Произошла ошибка при обнволении пользователя в БД");

        return _mapper.Map<CommentViewModel>(updatedComment);
    }
}
