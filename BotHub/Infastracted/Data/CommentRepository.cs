using Domain.Entities;
using Domain.Interfaces;
using Infastracted.EF;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data;

/// <summary>
/// Репозиторий для работы с комментариями.
/// </summary>
public class CommentRepository(BotHubDbContext context) 
    : IRepository<Comment, Guid>
{
    /// <inheritdoc/>
    public async Task<IList<Comment>> GetAllAsync()
    {
        return await context.Comments.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Comment?> GetByIdAsync(Guid id)
    {
        return await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Comment> CreateAsync(Comment entity)
    {
        var createdComment = await context.Comments.AddAsync(entity);
        await SaveChangesAsync();

        return createdComment.Entity;
    }

    /// <inheritdoc/>
    public async Task<Comment> DeleteAsync(Comment entity)
    {
        var deletedComment = context.Comments.Remove(entity);
        await SaveChangesAsync();

        return deletedComment.Entity;
    }

    /// <inheritdoc/>
    public async Task<Comment> UpdateAsync(Comment entity)
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
