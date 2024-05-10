using Newtonsoft.Json;

namespace Application.ViewModels.UserViewModels;

/// <summary>
///     Представляет модель создания пользователя
/// </summary>
public record RegisterViewModel
{
    /// <summary>
    ///     Получает или задает логин пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "login")]
    public required string Login { get; init; }

    /// <summary>
    ///     Получает или задает адрес электронной почты пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "email")]
    public required string Email { get; init; }

    /// <summary>
    ///     Получает или задает пароль пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "password")]
    public required string Password { get; init; }

    /// <summary>
    ///     Получает или задает повторный пароль пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "repeatedPassword")]
    public required string RepeatedPassword { get; init; }

    /// <summary>
    ///     Получает или задает уникальный идентификатор поста.
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public Guid Id => Guid.NewGuid();

    /// <summary>
    ///     Получает или задает список идентификаторов постов, которые сделал пользователь.
    /// </summary>
    [JsonProperty(PropertyName = "postIds")]
    public IList<Guid> PostIds => [];

    /// <summary>
    ///     Получает или задает список идентификаторов комментариев, которые сделал пользователь.
    /// </summary>
    [JsonProperty(PropertyName = "commentIds")]
    public IList<Guid> CommentIds => [];

    /// <summary>
    ///     Получает имя пользователя, которое совпадает с адресом электронной почты.
    /// </summary>
    [JsonProperty(PropertyName = "userName")]
    public string UserName => Email;

    /// <summary>
    ///     Получает дату регистрации.
    /// </summary>
    [JsonProperty(PropertyName = "registerDate")]
    public DateTime RegisterDate => DateTime.Now;
}