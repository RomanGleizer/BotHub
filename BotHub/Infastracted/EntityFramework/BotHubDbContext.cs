using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.EntityFramework;

/// <summary>
///     Представляет контекст базы данных для приложения BotHub.
/// </summary>
/// <remarks>
///     Инициализирует новый экземпляр контекста базы данных BotHub.
/// </remarks>
public sealed class BotHubDbContext : IdentityDbContext<User>
{
    public BotHubDbContext(DbContextOptions<BotHubDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    ///     Получает или устанавливает набор пользователей
    /// </summary>
    public override DbSet<User> Users { get; set; }

    /// <summary>
    ///     Получает или устанавливает набор постов
    /// </summary>
    public DbSet<Post> Posts { get; init; }

    /// <summary>
    ///     Получает или устанавливает набор комментариев
    /// </summary>
    public DbSet<Comment> Comments { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}