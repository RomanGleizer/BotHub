using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Получает все сущности из репозитория асинхронно.
    /// </summary>
    /// <returns>Список всех сущностей.</returns>
    Task<IList<User>> GetAllAsync();

    /// <summary>
    /// Получает сущность из репозитория по идентификатору асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <returns>Сущность с указанным идентификатором.</returns>
    Task<User?> GetByIdAsync(Guid id);

    /// <summary>
    /// Создает новую сущность в репозитории асинхронно.
    /// </summary>
    /// <param name="entity">Сущность для создания.</param>
    /// <returns>Созданная сущность.</returns>
    Task<IdentityResult?> CreateAsync(User entity, string password);

    /// <summary>
    /// Удаляет сущность из репозитория асинхронно.
    /// </summary>
    /// <param name="entity">Сущность для удаления.</param>
    /// <returns>Удаленная сущность.</returns>
    Task<IdentityResult?> DeleteAsync(User entity);

    /// <summary>
    /// Обновляет сущность в репозитории асинхронно.
    /// </summary>
    /// <param name="entity">Сущность для обновления.</param>
    /// <returns>Обновленная сущность.</returns>
    Task<IdentityResult?> UpdateAsync(User entity);
}
