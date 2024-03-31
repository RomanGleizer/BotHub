using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infastracted.Data;
using Infastracted.EF;
using Microsoft.AspNetCore.Identity;

namespace BotHub.Server.Extensions;

/// <summary>
/// Предоставляет методы расширения для IServiceCollection для настройки сервисов, связанных с репозиториями, сервисами и настраиваемой аутентификацией.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Добавляет сервисы репозиториев в указанный IServiceCollection.
    /// </summary>
    /// <param name="services">Интерфейс IServiceCollection, в который добавляются сервисы репозиториев.</param>
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IRepository<Post, Guid>, PostRepository>();
        services.AddTransient<IRepository<Comment, Guid>, CommentRepository>();
    }

    /// <summary>
    /// Добавляет сервисы служб в указанный IServiceCollection.
    /// </summary>
    /// <param name="services">Интерфейс IServiceCollection, в который добавляются службы.</param>
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IPostService, PostService>();
        services.AddTransient<ICommentService, CommentService>();
    }

    /// <summary>
    /// Добавляет настраиваемые сервисы аутентификации в указанный IServiceCollection.
    /// </summary>
    /// <param name="services">Интерфейс IServiceCollection, в который добавляются настраиваемые сервисы аутентификации.</param>
    public static void AddCustomAuthentication(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireDigit = true;
            options.User.RequireUniqueEmail = false;
            options.SignIn.RequireConfirmedAccount = false;
        })
        .AddEntityFrameworkStores<BotHubDbContext>()
        .AddDefaultTokenProviders();
    }

    /// <summary>
    /// Добавляет настройки CORS в указанный IServiceCollection.
    /// </summary>
    /// <param name="services">Интерфейс IServiceCollection, в который добавляются настройки CORS.</param>
    /// <param name="corsOrigins">Массив строк, представляющий собой разрешенные источники для CORS.</param>
    public static void AddCustomCors(this IServiceCollection services, string[]? corsOrigins)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("ReactPolicy", builder =>
            {
                if (corsOrigins != null)
                {
                    builder.WithOrigins(corsOrigins)
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }
                else
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }
            });
        });
    }
}