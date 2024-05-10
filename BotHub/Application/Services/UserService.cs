using System.Text;
using Application.Interfaces;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

/// <summary>
///     Сервис для управления пользователями.
/// </summary>
/// <remarks>
///     Инициализирует новый экземпляр класса UserService.
/// </remarks>
/// <param name="repository">Репозиторий пользователей.</param>
/// <param name="mapper">Маппер для преобразования между сущностями и моделями представления.</param>
/// <param name="signInManager">Менеджер для аутентификации пользователей.</param>
public class UserService(IUserRepository repository, IMapper mapper, SignInManager<User> signInManager)
    : IUserService<string>
{
    /// <inheritdoc />
    public async Task<IList<UserViewModel>> GetAllAsync()
    {
        var users = await repository.GetAllAsync();
        return mapper.Map<IList<UserViewModel>>(users);
    }

    /// <inheritdoc />
    public async Task<UserViewModel> GetByIdAsync(string id)
    {
        var existingUserIdentityResult = await repository.GetByIdAsync(id)
                                         ?? throw new Exception("Не удалось найти пользователя в БД");

        return mapper.Map<UserViewModel>(existingUserIdentityResult);
    }

    /// <inheritdoc />
    public async Task<IdentityResult> DeleteAsync(string id)
    {
        var user = await repository.GetByIdAsync(id)
                   ?? throw new Exception("Не удалось найти пользователя в БД");

        var deletedUser = await repository.DeleteAsync(user)
                          ?? throw new Exception("Произошла ошибка при удалении пользователя из БД");

        return deletedUser;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> UpdateAsync(string id, UpdateUserViewModel model)
    {
        var existingUser = await repository.GetByIdAsync(id)
                           ?? throw new Exception("Не удалось найти пользователя в БД");

        mapper.Map(model, existingUser);

        var updatedUser = await repository.UpdateAsync(existingUser)
                          ?? throw new Exception("Произошла ошибка при обновлении пользователя в БД");

        return updatedUser;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> RegisterAsync(RegisterViewModel model, string password)
    {
        if (model.RepeatedPassword != password)
            throw new Exception("Пароли не совпадают");
        
        var entity = mapper.Map<User>(model);
        var createdEntity = await repository.CreateAsync(entity, password)
                            ?? throw new Exception("Произошла ошибка при добавлении пользователя в БД");

        if (createdEntity.Succeeded) 
            return createdEntity;

        var errorsMessage = BuildErrorMessageFromIdentityResult(createdEntity);
        throw new Exception($"Произошла одна или несколько ошибок при регистрации: {errorsMessage}");
    }

    /// <inheritdoc />
    public async Task<SignInResult> SignInAsync(
        string userName,
        string password,
        bool isPersistent,
        bool lockoutOnFailure)
    {
        var signInResult = await signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);

        if (signInResult.Succeeded)
            return signInResult;

        throw new Exception("Неверный логин или пароль");
    }

    private string BuildErrorMessageFromIdentityResult(IdentityResult identityResult)
    {
        var errorMessage = new StringBuilder();
        foreach (var error in identityResult.Errors)
            errorMessage.Append($"{error.Description}\n");
        throw new Exception(errorMessage.ToString());
    }
}