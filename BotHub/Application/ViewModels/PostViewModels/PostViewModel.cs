using Newtonsoft.Json;

namespace Application.ViewModels.PostViewModels;

/// <summary>
///     Представляет модель представления поста
/// </summary>
public record PostViewModel
{
    /// <summary>
    ///     Получает или задает уникальный идентификатор поста.
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public required Guid Id { get; init; }

    /// <summary>
    ///     Получает или задает название поста.
    /// </summary>
    [JsonProperty(PropertyName = "title")]
    public required string Title { get; init; }

    /// <summary>
    ///     Получает или задает краткое описание бота.
    /// </summary>
    [JsonProperty(PropertyName = "shortDescription")]
    public required string ShortDescription { get; init; }

    /// <summary>
    ///     Получает или задает полное описание бота.
    /// </summary>
    [JsonProperty(PropertyName = "fullDescription")]
    public required string FullDescription { get; init; }

    /// <summary>
    ///     Получает или задает возможности бота, описываемые в посте.
    /// </summary>
    [JsonProperty(PropertyName = "botPossibilities")]
    public required string BotPossibilities { get; init; }

    /// <summary>
    ///     Получает или задает ссылку на бота, упомянутого в посте.
    /// </summary>
    [JsonProperty(PropertyName = "botLink")]
    public required string BotLink { get; init; }

    /// <summary>
    ///     Получает или задает ссылку на иконку бота.
    /// </summary>
    [JsonProperty(PropertyName = "botImage")]
    public required string BotImage { get; init; }

    /// <summary>
    ///     Получает или задает дату создания бота.
    /// </summary>
    [JsonProperty(PropertyName = "creationDate")]
    public required DateTime CreationDate { get; init; }

    /// <summary>
    ///     Получает или задает количество лайков.
    /// </summary>
    [JsonProperty(PropertyName = "likesAmount")]
    public required int LikesAmount { get; init; }

    /// <summary>
    ///     Получает или задает количество дизлайков.
    /// </summary>
    [JsonProperty(PropertyName = "dislikesAmount")]
    public required int DislikesAmount { get; init; }

    /// <summary>
    ///     Получает или задает список постов, оставленных к комментарию.
    /// </summary>
    [JsonProperty(PropertyName = "commentIds")]
    public required IList<Guid> CommentIds { get; init; }

    /// <summary>
    ///     Получает или задает идентификатор автора поста.
    /// </summary>
    [JsonProperty(PropertyName = "authorId")]
    public required Guid AuthorId { get; init; }
}