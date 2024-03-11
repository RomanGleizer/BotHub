using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces;

/// <summary>
/// Представляет интерфейс сервиса пользователей.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Получает все модели представления пользователей асинхронно.
    /// </summary>
    /// <returns>Список всех моделей представления пользователей.</returns>
    Task<IList<UserViewModel>> GetAllAsync();

    /// <summary>
    /// Получает модель представления пользователя по указанному идентификатору асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <returns>Модель представления пользователя с указанным идентификатором.</returns>
    Task<UserViewModel> GetByIdAsync(Guid id);

    /// <summary>
    /// Создает нового пользователя.
    /// </summary>
    /// <param name="user">Модель представления нового пользователя.</param>
    /// <returns>Модель представления созданного пользователя.</returns>
    Task<IdentityResult> Create(CreateUserViewModel user, string password);

    /// <summary>
    /// Удаляет пользователя по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    Task<IdentityResult> Delete(Guid id);

    /// <summary>
    /// Обновляет информацию о пользователе.
    /// </summary>
    /// <param name="user">Модель представления пользователя с обновленной информацией.</param>
    Task<IdentityResult> Update(Guid id, UpdateUserViewModel user);
}
