using Domain.Interfaces;

namespace Domain.Entities;

/// <summary>
/// Представляет сущность комментария с свойствами идентификации и дополнительной информацией о коментарии.
/// </summary>
public record Comment : IDbEntity<Guid>
{
    /// <summary>
    /// Получает или задает уникальный идентификатор комментария.
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Получает или задает текст комментария.
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Получает или задает количество лайков.
    /// </summary>
    public required int LikesAmount { get; init; }

    /// <summary>
    /// Получает или задает количество дизлайков.
    /// </summary>
    public required int DislikesAmount { get; init; }

    /// <summary>
    /// Получает или задает дату создания комментария.
    /// </summary>
    public required DateTime CreationDate { get; init; }

    /// <summary>
    /// Получает или задает уникальный идентификатор пользователя, который оставил комментарий.
    /// </summary>
    public required string AuthorId { get; init; }
    
    /// <summary>
    /// Получает или задает уникальный идентификатор поста, к которому оставили комментарий.
    /// </summary>
    public required Guid PostId { get; init; }
}
