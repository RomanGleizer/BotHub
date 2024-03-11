namespace Domain.Interfaces;

/// <summary>
/// Представляет интерфейс для сущностей базы данных с указанием типа идентификатора.
/// </summary>
/// <typeparam name="TId">Тип идентификатора сущности.</typeparam>
public interface IDbEntity<TId>
{
    /// <summary>
    /// Получает или задает уникальный идентификатор сущности.
    /// </summary>
    TId Id { get; init; }
}
