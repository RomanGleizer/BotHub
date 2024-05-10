using Newtonsoft.Json;

namespace Application.ViewModels.UserViewModels;

/// <summary>
///     Представляет модель обновления пользователя
/// </summary>
public record UpdateUserViewModel
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
    ///     Получает имя пользователя, которое совпадает с адресом электронной почты.
    /// </summary>
    [JsonProperty(PropertyName = "userName")]
    public string UserName => Email;
}