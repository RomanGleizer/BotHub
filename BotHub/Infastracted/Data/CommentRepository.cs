using Domain.Entities;
using Domain.Interfaces;
using Infastracted.EF;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data;

/// <summary>
/// Репозиторий для работы с комментариями.
/// </summary>
public class CommentRepository(BotHubDbContext context) : IRepository<Comment, Guid>
{
    private readonly BotHubDbContext _context = context;

    /// <inheritdoc/>
    public async Task<IList<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Comment?> GetByIdAsync(Guid id)
    {
        return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Comment> CreateAsync(Comment entity)
    {
        var createdComment = await _context.Comments.AddAsync(entity);
        await SaveChangesAsync();

        return createdComment.Entity;
    }

    /// <inheritdoc/>
    public async Task<Comment> DeleteAsync(Comment entity)
    {
        var deletedComment = _context.Comments.Remove(entity);
        await SaveChangesAsync();

        return deletedComment.Entity;
    }

    /// <inheritdoc/>
    public async Task<Comment> UpdateAsync(Comment entity)
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
