using Domain.Interfaces;
using Domain.Entities.Identity;
using Infastracted.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Infastracted.Data;

public class UserRepository(BotHubDbContext dbContext, UserManager<User> userManager) : IUserRepository
{
    private readonly BotHubDbContext _context = dbContext;
    private readonly UserManager<User> _userManager = userManager;

    /// <inheritdoc/>
    public async Task<IList<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _userManager.FindByIdAsync(id.ToString());
    }

    /// <inheritdoc/>
    public async Task<IdentityResult?> CreateAsync(User entity, string password)
    {
        var createdEntity = await _userManager.CreateAsync(entity, password);
        return createdEntity;
    }

    /// <inheritdoc/>
    public async Task<IdentityResult?> DeleteAsync(User entity)
    {
        var deletedEntity = await _userManager.DeleteAsync(entity);
        return deletedEntity;
    }

    /// <inheritdoc/>
    public async Task<IdentityResult?> UpdateAsync(User entity)
    {
        var updatedEntity = await _userManager.UpdateAsync(entity);
        return updatedEntity;
    }
}