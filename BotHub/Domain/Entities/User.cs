using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

/// <summary>
///     Представляет сущность пользователя со свойствами идентификации и дополнительной информацией о пользователе.
/// </summary>
public class User : IdentityUser, IDbEntity<string>
{
    /// <summary>
    ///     Получает или задает логин пользователя.
    /// </summary>
    [MaxLength(100)]
    public required string Login { get; init; }

    /// <summary>
    ///     Получает или задает адрес электронной почты пользователя.
    /// </summary>
    [MaxLength(100)]
    public new required string Email { get; init; }

    /// <summary>
    ///     Получает или задает список идентификаторов постов, которые сделал пользователь.
    /// </summary>
    public required IList<Guid> PostIds { get; init; }

    /// <summary>
    ///     Получает или задает список идентификаторов комментариев, которые сделал пользователь.
    /// </summary>
    public required IList<Guid> CommentIds { get; init; }

    /// <summary>
    ///     Получает имя пользователя, которое совпадает с адресом электронной почты.
    /// </summary>
    public override string UserName => Email;

    /// <summary>
    ///     Получает или задает уникальный идентификатор пользователя.
    /// </summary>
    [MaxLength(100)]
    public new required string Id { get; init; }
}