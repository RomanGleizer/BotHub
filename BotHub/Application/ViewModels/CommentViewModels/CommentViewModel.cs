using Newtonsoft.Json;

namespace Application.ViewModels.CommentViewModels;

/// <summary>
/// Представляет модель представления комментария
/// </summary>
public record CommentViewModel
{
    /// <summary>
    /// Получает или задает уникальный идентификатор комментария.
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Получает или задает текст комментария.
    /// </summary>
    [JsonProperty(PropertyName = "text")]
    public required string Text { get; init; }

    /// <summary>
    /// Получает или задает количество лайков.
    /// </summary>
    [JsonProperty(PropertyName = "likesAmount")]
    public required int LikesAmount { get; init; }

    /// <summary>
    /// Получает или задает количество дизлайков.
    /// </summary>
    [JsonProperty(PropertyName = "dislikesAmount")]
    public required int DislikesAmount { get; init; }

    /// <summary>
    /// Получает или задает дату создания комментария.
    /// </summary>
    [JsonProperty(PropertyName = "dislikesAmount")]
    public required DateTime CreationDate { get; init; }

    /// <summary>
    /// Получает или задает уникальный идентификатор пользователя, который оставил комментарий.
    /// </summary>
    [JsonProperty(PropertyName = "authorId")]
    public required string AuthorId { get; init; }
}
