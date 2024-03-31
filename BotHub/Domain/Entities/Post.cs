using Domain.Interfaces;

namespace Domain.Entities;

/// <summary>
/// Представляет сущность поста с свойствами идентификации и дополнительной информацией о посте.
/// </summary>
public record Post : IDbEntity<Guid>
{
    /// <summary>
    /// Получает или задает уникальный идентификатор поста.
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Получает или задает название поста.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Получает или задает краткое описание бота.
    /// </summary>
    public required string ShortDescription { get; init; }

    /// <summary>
    /// Получает или задает полное описание бота.
    /// </summary>
    public required string FullDescription { get; init; }

    /// <summary>
    /// Получает или задает возможности бота, описываемые в посте.
    /// </summary>
    public required string BotСapabilities { get; init; }

    /// <summary>
    /// Получает или задает ссылку на бота, упомянутого в посте.
    /// </summary>
    public required string BotLink { get; init; }

    /// <summary>
    /// Получает или задает ссылку на иконку бота.
    /// </summary>
    public required string BotImage { get; init; }

    /// <summary>
    /// Получает или задает дату создания бота.
    /// </summary>
    public required DateTime CreationDate { get; init; }

    /// <summary>
    /// Получает или задает количество лайков.
    /// </summary>
    public required int LikesAmount { get; init; }

    /// <summary>
    /// Получает или задает количество дизлайков.
    /// </summary>
    public required int DislikesAmount { get; init; }

    // комментарии

    /// <summary>
    /// Получает или задает идентификатор автора поста.
    /// </summary>
    public required Guid AuthorId { get; init; }
}
