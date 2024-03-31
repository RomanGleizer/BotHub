using Newtonsoft.Json;

namespace Application.ViewModels.UserViewModels;

/// <summary>
/// Представляет модель создания пользователя
/// </summary>
public record CreateUserViewModel
{
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
    /// Получает или задает дату рождения пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "birthDay")]
    public required DateTime BirthDay { get; init; }

    /// <summary>
    /// Получает или задает пароль пользователя.
    /// </summary>
    [JsonProperty(PropertyName = "password")]
    public required string Password { get; init; }

    /// <summary>
    /// Получает или задает уникальный идентификатор поста.
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public Guid Id => Guid.NewGuid();

    /// <summary>
    /// Получает или задает список идентификаторов постов, которые сделал пользователь.
    /// </summary>
    [JsonProperty(PropertyName = "postIds")]
    public IList<Guid> PostIds => [];

    /// <summary>
    /// Получает имя пользователя, которое совпадает с адресом электронной почты.
    /// </summary>
    [JsonProperty(PropertyName = "userName")]
    public string UserName => Email;

    /// <summary>
    /// Получает дату регистрации.
    /// </summary>
    [JsonProperty(PropertyName = "registerDate")]
    public DateTime RegisterDate => DateTime.Now;
}