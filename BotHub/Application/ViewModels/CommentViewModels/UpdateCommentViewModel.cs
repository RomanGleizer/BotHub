using Newtonsoft.Json;

namespace Application.ViewModels.CommentViewModels;

/// <summary>
///     Представляет модель обновления комментария
/// </summary>
public class UpdateCommentViewModel
{
    /// <summary>
    ///     Получает или задает текст комментария.
    /// </summary>
    [JsonProperty(PropertyName = "text")]
    public required string Text { get; init; }

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
}