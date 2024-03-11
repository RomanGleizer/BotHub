using Application.Interfaces;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

/// <summary>
/// Сервис для управления пользователями.
/// </summary>
/// <remarks>
/// Инициализирует новый экземпляр класса UserService.
/// </remarks>
/// <param name="repository">Репозиторий пользователей.</param>
/// <param name="mapper">Маппер для преобразования между сущностями и моделями представления.</param>
public class UserService(IUserRepository repository, IMapper mapper) : IUserService
{
    private readonly IUserRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc/>
    public async Task<IList<UserViewModel>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        return _mapper.Map<IList<UserViewModel>>(users);
    }

    /// <inheritdoc/>
    public async Task<UserViewModel> GetByIdAsync(Guid id)
    {
        var existingUserIdentityResult = await _repository.GetByIdAsync(id) 
            ?? throw new Exception("An error occurred while getting the user to the database");

        return _mapper.Map<UserViewModel>(existingUserIdentityResult);
    }

    /// <inheritdoc/>
    public async Task<IdentityResult> Create(CreateUserViewModel model, string password)
    {
        var entity = _mapper.Map<User>(model);
        var createdEntity = await _repository.CreateAsync(entity, password) 
            ?? throw new Exception("An error occurred while creating the user to the database");

        return createdEntity;
    }

    /// <inheritdoc/>
    public async Task<IdentityResult> Delete(Guid id)
    {
        var user = await _repository.GetByIdAsync(id) 
            ?? throw new Exception("User was not found in database");

        var deletedUser = await _repository.DeleteAsync(user) 
            ?? throw new Exception("An error occurred while deleting the user to the database");

        return deletedUser;
    }

    /// <inheritdoc/>
    public async Task<IdentityResult> Update(Guid id, UpdateUserViewModel model)
    {
        var existingUser = await _repository.GetByIdAsync(id) 
            ?? throw new Exception("User was not found in database");

        _mapper.Map(model, existingUser);

        var updatedUser = await _repository.UpdateAsync(existingUser)
            ?? throw new Exception("An error occurred while updating the user to the database");

        return updatedUser;
    }
}