using Application.ViewModels.PostViewModels;

namespace Application.Interfaces;

/// <summary>
/// Представляет интерфейс сервиса сущности поста.
/// </summary>
public interface IPostService
{
    /// <summary>
    /// Получает все модели представления постов асинхронно.
    /// </summary>
    /// <returns>Список всех моделей представления постов.</returns>
    Task<IList<PostViewModel>> GetAllAsync();

    /// <summary>
    /// Получает модель представления поста по указанному идентификатору асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор поста.</param>
    /// <returns>Модель представления поста с указанным идентификатором.</returns>
    Task<PostViewModel> GetByIdAsync(Guid id);

    /// <summary>
    /// Создает новый пост.
    /// </summary>
    /// <param name="post">Модель представления создания поста.</param>
    /// <returns>Модель представления созданного поста.</returns>
    Task<PostViewModel> CreateAsync(CreatePostViewModel post);

    /// <summary>
    /// Удаляет пост по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор поста.</param>
    Task<PostViewModel> DeleteAsync(Guid id);

    /// <summary>
    /// Обновляет информацию о посте.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="post">Модель представления поста с обновленной информацией.</param>
    Task<PostViewModel> UpdateAsync(Guid id, UpdatePostViewModel post);
}