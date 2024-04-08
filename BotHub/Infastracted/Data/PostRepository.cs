using Domain.Entities;
using Domain.Interfaces;
using Infastracted.EF;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data;

/// <summary>
/// Репозиторий для работы с постами.
/// </summary>
public class PostRepository(BotHubDbContext context)
    : IRepository<Post, Guid>
{
    /// <inheritdoc/>
    public async Task<IList<Post>> GetAllAsync()
    {
        return await context.Posts.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Post> CreateAsync(Post entity)
    {
        var createdEntityEntry = await context.Posts.AddAsync(entity);
        await SaveChangesAsync();

        return createdEntityEntry.Entity;
    }

    /// <inheritdoc/>
    public async Task<Post> DeleteAsync(Post entity)
    {
        var removedEntity = context.Posts.Remove(entity);
        await SaveChangesAsync();

        return removedEntity.Entity;
    }

    /// <inheritdoc/>
    public async Task<Post> UpdateAsync(Post entity)
    {
        var entityEntry = context.Entry(entity);
        entityEntry.State = EntityState.Modified;
        await SaveChangesAsync();

        return entityEntry.Entity;
    }

    /// <inheritdoc/>
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}