using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

/// <summary>
/// Представляет сущность пользователя с свойствами идентификации и дополнительной информацией о пользователе.
/// </summary>
public class User : IdentityUser, IDbEntity<Guid>
{
    /// <summary>
    /// Получает или задает уникальный идентификатор пользователя.
    /// </summary>
    public required new Guid Id { get; init; }

    /// <summary>
    /// Получает или задает имя пользователя.
    /// </summary>
    public required string FirstName { get; init; }

    /// <summary>
    /// Получает или задает фамилию пользователя.
    /// </summary>
    public required string LastName { get; init; }

    /// <summary>
    /// Получает или задает адрес электронной почты пользователя.
    /// </summary>
    public required new string Email { get; init; }

    /// <summary>
    /// Получает или задает номер телефона пользователя.
    /// </summary>
    public required new string PhoneNumber { get; init; }

    /// <summary>
    /// Получает или задает дату рождения пользователя.
    /// </summary>
    public required DateTime BirthDay { get; init; }

    /// <summary>
    /// Получает или задает дату регистрации пользователя.
    /// </summary>
    public required DateTime RegisterDate { get; init; }

    /// <summary>
    /// Получает имя пользователя, которое совпадает с адресом электронной почты.
    /// </summary>
    public override string UserName => Email;
}
