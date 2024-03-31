using Newtonsoft.Json;

namespace Application.ViewModels.PostViewModels;

/// <summary>
/// Представляет модель обновления поста
/// </summary>
public record UpdatePostViewModel
{
    /// <summary>
    /// Получает или задает название поста.
    /// </summary>
    [JsonProperty(PropertyName = "title")]
    public required string Title { get; init; }

    /// <summary>
    /// Получает или задает краткое описание бота.
    /// </summary>
    [JsonProperty(PropertyName = "shortDescription")]
    public required string ShortDescription { get; init; }

    /// <summary>
    /// Получает или задает полное описание бота.
    /// </summary>
    [JsonProperty(PropertyName = "fullDescription")]
    public required string FullDescription { get; init; }

    /// <summary>
    /// Получает или задает возможности бота, описываемые в посте.
    /// </summary>
    [JsonProperty(PropertyName = "botСapabilities")]
    public required string BotСapabilities { get; init; }

    /// <summary>
    /// Получает или задает ссылку на бота, упомянутого в посте.
    /// </summary>
    [JsonProperty(PropertyName = "botLink")]
    public required string BotLink { get; init; }

    /// <summary>
    /// Получает или задает ссылку на иконку бота.
    /// </summary>
    [JsonProperty(PropertyName = "botImage")]
    public required string BotImage { get; init; }
}
