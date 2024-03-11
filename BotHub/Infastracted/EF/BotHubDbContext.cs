using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.EF;

/// <summary>
/// Представляет контекст базы данных для приложения BotHub.
/// </summary>
/// <remarks>
/// Инициализирует новый экземпляр контекста базы данных BotHub.
/// </remarks>
/// <param name="options">Параметры для настройки контекста базы данных.</param>
public class BotHubDbContext : IdentityDbContext<User>
{
    /// <summary>
    /// Получает или устанавливает набор пользователей
    /// </summary>
    public override DbSet<User> Users { get; set; }

    public BotHubDbContext(DbContextOptions<BotHubDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
