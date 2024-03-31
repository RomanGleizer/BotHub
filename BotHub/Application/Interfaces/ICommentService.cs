using Application.ViewModels.CommentViewModels;
using Application.ViewModels.PostViewModels;

namespace Application.Interfaces;

/// <summary>
/// Представляет интерфейс сервиса сущности комментария.
/// </summary>
public interface ICommentService
{
    // <summary>
    /// Получает все модели представления комментариев асинхронно.
    /// </summary>
    /// <returns>Список всех моделей представления комментариев.</returns>
    Task<IList<CommentViewModel>> GetAllAsync();

    /// <summary>
    /// Получает модель представления комментария по указанному идентификатору асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор комментария.</param>
    /// <returns>Модель представления комментария с указанным идентификатором.</returns>
    Task<CommentViewModel> GetByIdAsync(Guid id);

    /// <summary>
    /// Создает новый комментарий.
    /// </summary>
    /// <param name="user">Модель представления нового комментария.</param>
    /// <returns>Модель представления созданного комментария.</returns>
    Task<CommentViewModel> CreateAsync(CreateCommentViewModel post);

    /// <summary>
    /// Удаляет комментарий по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор комментария.</param>
    Task<CommentViewModel> DeleteAsync(Guid id);

    /// <summary>
    /// Обновляет информацию комментария.
    /// </summary>
    /// <param name="user">Модель представления комментария с обновленной информацией.</param>
    Task<CommentViewModel> UpdateAsync(Guid id, UpdateCommentViewModel user);
}
