using Domain.Interfaces;
using Infastracted.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;

namespace Infastracted.Data;

/// <summary>
/// Репозиторий для работы с пользователями.
/// </summary>
public class UserRepository(BotHubDbContext dbContext, UserManager<User> userManager) 
    : IUserRepository
{
    /// <inheritdoc/>
    public async Task<IList<User>> GetAllAsync()
    {
        return await dbContext.Users.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<User?> GetByIdAsync(string id)
    {
        return await userManager.FindByIdAsync(id);
    }

    /// <inheritdoc/>
    public async Task<IdentityResult?> CreateAsync(User entity, string password)
    {
        var createdEntity = await userManager.CreateAsync(entity, password);
        return createdEntity;
    }

    /// <inheritdoc/>
    public async Task<IdentityResult?> DeleteAsync(User entity)
    {
        var deletedEntity = await userManager.DeleteAsync(entity);
        return deletedEntity;
    }

    /// <inheritdoc/>
    public async Task<IdentityResult?> UpdateAsync(User entity)
    {
        var updatedEntity = await userManager.UpdateAsync(entity);
        return updatedEntity;
    }
}