using Domain.Entities;
using Domain.Interfaces;
using Infastracted.EF;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data;

/// <summary>
/// Репозиторий для работы с постами.
/// </summary>
public class PostRepository(BotHubDbContext context) : IRepository<Post, Guid>
{
    private readonly BotHubDbContext _context = context;

    /// <inheritdoc/>
    public async Task<IList<Post>> GetAllAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Post> CreateAsync(Post entity)
    {
        var createdEntityEntry = await _context.Posts.AddAsync(entity);
        await SaveChangesAsync();

        return createdEntityEntry.Entity;
    }

    /// <inheritdoc/>
    public async Task<Post> DeleteAsync(Post entity)
    {
        var removedEntity = _context.Posts.Remove(entity);
        await SaveChangesAsync();

        return removedEntity.Entity;
    }

    /// <inheritdoc/>
    public async Task<Post> UpdateAsync(Post entity)
    {
        var entityEntry = _context.Entry(entity);
        entityEntry.State = EntityState.Modified;
        await SaveChangesAsync();

        return entityEntry.Entity;
    }

    /// <inheritdoc/>
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
