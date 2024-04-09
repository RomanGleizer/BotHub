namespace Domain.Interfaces;

/// <summary>
///     Представляет интерфейс репозитория для работы с сущностями базы данных.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TId">Тип идентификатора сущности.</typeparam>
public interface IRepository<TEntity, in TId>
    where TEntity : IDbEntity<TId>
{
    /// <summary>
    ///     Получает все сущности из репозитория асинхронно.
    /// </summary>
    /// <returns>Список всех сущностей.</returns>
    Task<IList<TEntity>> GetAllAsync();

    /// <summary>
    ///     Получает сущность из репозитория по идентификатору асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <returns>Сущность с указанным идентификатором.</returns>
    Task<TEntity?> GetByIdAsync(TId id);

    /// <summary>
    ///     Создает новую сущность в репозитории асинхронно.
    /// </summary>
    /// <param name="entity">Сущность для создания.</param>
    /// <returns>Созданная сущность.</returns>
    Task<TEntity> CreateAsync(TEntity entity);

    /// <summary>
    ///     Удаляет сущность из репозитория асинхронно.
    /// </summary>
    /// <param name="entity">Сущность для удаления.</param>
    /// <returns>Удаленная сущность.</returns>
    Task<TEntity> DeleteAsync(TEntity entity);

    /// <summary>
    ///     Обновляет сущность в репозитории асинхронно.
    /// </summary>
    /// <param name="entity">Сущность для обновления.</param>
    /// <returns>Обновленная сущность.</returns>
    Task<TEntity> UpdateAsync(TEntity entity);

    /// <summary>
    ///     Сохраняет все изменения, внесенные в репозиторий асинхронно.
    /// </summary>
    Task SaveChangesAsync();
}