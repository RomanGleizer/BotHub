using Newtonsoft.Json;

namespace Application.ViewModels.CommentViewModels;

/// <summary>
/// Представляет модель создания комментария
/// </summary>
public class CreateCommentViewModel
{
    /// <summary>
    /// Получает или задает текст комментария.
    /// </summary>
    [JsonProperty(PropertyName = "text")]
    public required string Text { get; init; }

    /// <summary>
    /// Получает или задает уникальный идентификатор пользователя, который оставил комментарий.
    /// </summary>
    [JsonProperty(PropertyName = "authorId")]
    public required string AuthorId { get; init; }

    /// <summary>
    /// Получает или задает уникальный идентификатор поста, который прокоментировали.
    /// </summary>
    [JsonProperty(PropertyName = "postId")]
    public required Guid PostId { get; init; }

    /// <summary>
    /// Получает или задает уникальный идентификатор комментария.
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public Guid Id => Guid.NewGuid();

    /// <summary>
    /// Получает или задает дату создания комментария.
    /// </summary>
    [JsonProperty(PropertyName = "creationDate")]
    public DateTime CreationDate => DateTime.Now;

    /// <summary>
    /// Получает или задает количество лайков.
    /// </summary>
    [JsonProperty(PropertyName = "likesAmount")]
    public int LikesAmount => 0;

    /// <summary>
    /// Получает или задает количество дизлайков.
    /// </summary>
    [JsonProperty(PropertyName = "dislikesAmount")]
    public int DislikesAmount => 0;
}