using Newtonsoft.Json;

namespace Application.ViewModels.UserViewModels;

/// <summary>
/// Представляет модель представления пользователя
/// </summary>
public record UserViewModel
{
    /// <summary>
    /// Получает или задает уникальный идентификатор пользователя
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; init; }

    /// <summary>
    /// Получает или задает имя пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "firstName")]
    public required string FirstName { get; init; }

    /// <summary>
    /// Получает или задает фамилию пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "lastName")]
    public required string LastName { get; init; }

    /// <summary>
    /// Получает или задает адрес электронной почты пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "email")]
    public required string Email { get; init; }

    /// <summary>
    /// Получает или задает номер телефона пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "phone")]
    public required string PhoneNumber { get; init; }

    /// <summary>
    /// Получает или задает дату рождения пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "birthDay")]
    public required DateTime BirthDay { get; init; }

    /// <summary>
    /// Получает имя пользователя, которое совпадает с адресом электронной почты.
    /// </summary>
    [JsonProperty(PropertyName = "userName")]
    public string UserName => Email;
}
