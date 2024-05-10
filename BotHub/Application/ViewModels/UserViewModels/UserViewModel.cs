using Newtonsoft.Json;

namespace Application.ViewModels.UserViewModels;

/// <summary>
///     Представляет модель представления пользователя
/// </summary>
public record UserViewModel
{
    /// <summary>
    ///     Получает или задает уникальный идентификатор пользователя
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public required string Id { get; init; }

    /// <summary>
    ///     Получает или задает логин пользователя.
    /// </summary>
    public required string Login { get; init; }

    /// <summary>
    ///     Получает или задает адрес электронной почты пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "email")]
    public required string Email { get; init; }

    /// <summary>
    ///     Получает или задает список идентификаторов постов, которые сделал пользователь.
    /// </summary>
    [JsonProperty(PropertyName = "postIds")]
    public required IList<Guid> PostIds { get; init; }

    /// <summary>
    ///     Получает или задает список идентификаторов комментариев, которые сделал пользователь.
    /// </summary>
    [JsonProperty(PropertyName = "commentIds")]
    public required IList<Guid> CommentIds { get; init; }

    /// <summary>
    ///     Получает имя пользователя, которое совпадает с адресом электронной почты.
    /// </summary>
    [JsonProperty(PropertyName = "userName")]
    public string UserName => Email;
}