using Newtonsoft.Json;

namespace Application.ViewModels.UserViewModels;

public record LoginViewModel
{
    /// <summary>
    ///     Получает или задает имя пользователя, которое совпадает с адресом электронной почты.
    /// </summary>
    [JsonProperty(PropertyName = "userName")]
    public required string UserName { get; init; }

    /// <summary>
    ///     Получает или задает пароль пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "password")]
    public required string Password { get; init; }

    /// <summary>
    ///     Получает или задает состояние по запомнинаию пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "rememberMe")]
    public required bool RememberMe { get; init; }
}