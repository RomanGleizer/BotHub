using Newtonsoft.Json;

namespace Application.ViewModels.UserViewModels;

/// <summary>
///     Представляет модель обновления пользователя
/// </summary>
public record UpdateUserViewModel
{
    /// <summary>
    ///     Получает или задает имя пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "firstName")]
    public required string FirstName { get; init; }

    /// <summary>
    ///     Получает или задает фамилию пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "lastName")]
    public required string LastName { get; init; }

    /// <summary>
    ///     Получает или задает адрес электронной почты пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "email")]
    public required string Email { get; init; }

    /// <summary>
    ///     Получает или задает дату рождения пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "birthDay")]
    public required DateTime BirthDay { get; init; }

    /// <summary>
    ///     Получает или задает пароль пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "password")]
    public required string Password { get; init; }

    /// <summary>
    ///     Получает имя пользователя, которое совпадает с адресом электронной почты.
    /// </summary>
    [JsonProperty(PropertyName = "userName")]
    public string UserName => Email;
}