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
    Task<UserViewModel> GetByIdAsync(string id);

    /// <summary>
    /// Создает нового пользователя.
    /// </summary>
    /// <param name="user">Модель представления нового пользователя.</param>
    /// <param name="password">Пароль пользователя.</param>
    /// <returns>Модель представления созданного пользователя.</returns>
    Task<IdentityResult> CreateAsync(CreateUserViewModel user, string password);

    /// <summary>
    /// Удаляет пользователя по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    Task<IdentityResult> DeleteAsync(string id);

    /// <summary>
    /// Обновляет информацию о пользователе.
    /// </summary>
    /// <param name="id">Уникальный идентификатор пользователя.</param>
    /// <param name="user">Модель представления пользователя с обновленной информацией.</param>
    Task<IdentityResult> UpdateAsync(string id, UpdateUserViewModel user);
}