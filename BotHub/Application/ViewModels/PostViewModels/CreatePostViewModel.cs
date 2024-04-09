using Newtonsoft.Json;

namespace Application.ViewModels.PostViewModels;

/// <summary>
///     Представляет модель создания поста
/// </summary>
public record CreatePostViewModel
{
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

    // комментарии

    /// <summary>
    ///     Получает или задает идентификатор автора поста.
    /// </summary>
    [JsonProperty(PropertyName = "authorId")]
    public required string AuthorId { get; init; }

    /// <summary>
    ///     Получает или задает уникальный идентификатор поста.
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public Guid Id => Guid.NewGuid();

    /// <summary>
    ///     Получает или задает дату создания бота.
    /// </summary>
    [JsonProperty(PropertyName = "creationDate")]
    public DateTime CreationDate => DateTime.Now;

    /// <summary>
    ///     Получает или задает количество лайков.
    /// </summary>
    [JsonProperty(PropertyName = "likesAmount")]
    public int LikesAmount => 0;

    /// <summary>
    ///     Получает или задает количество дизлайков.
    /// </summary>
    [JsonProperty(PropertyName = "dislikesAmount")]
    public int DislikesAmount => 0;

    /// <summary>
    ///     Получает или задает список постов, оставленных к комментарию.
    /// </summary>
    [JsonProperty(PropertyName = "commentIds")]
    public IList<Guid> CommentIds => [];
}