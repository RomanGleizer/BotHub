using Application.Services;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace UserFunctionalTesting;

/// <summary>
/// Тесты функциональности пользователей.
/// </summary>
[TestFixture]
public class UserServiceTests
{
    /// <summary>
    /// Мок репозитория пользователей.
    /// </summary>
    private Mock<IUserRepository> _mockUserRepository;

    /// <summary>
    /// Мок IMapper.
    /// </summary>
    private Mock<IMapper> _mockMapper;

    /// <summary>
    /// Подготовка тестовой среды перед выполнением каждого теста.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();
    }

    /// <summary>
    /// Тестирование метода GetAllAsync. Возвращает список моделей представления пользователей.
    /// </summary>
    [Test]
    public async Task GetAllAsync_ReturnsListOfUserViewModel()
    {
        // Arrange
        var userService = new UserService(_mockUserRepository.Object, _mockMapper.Object);
        var userList = new List<User>();

        _mockUserRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(userList);
        _mockMapper.Setup(mapper => mapper.Map<IList<UserViewModel>>(userList)).Returns([]);

        var result = await userService.GetAllAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<IList<UserViewModel>>());
    }

    /// <summary>
    /// Тестирование метода GetByIdAsync. Возвращает модель представления пользователя по его идентификатору.
    /// </summary>
    [Test]
    public void GetByIdAsync_WithValidId_ReturnsUserViewModel()
    {
        var userService = new UserService(_mockUserRepository.Object, _mockMapper.Object);

        var userEntity = new User
        {
            Id = Guid.NewGuid(),
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            PhoneNumber = string.Empty,
            BirthDay = default,
            RegisterDate = default
        };

        var userViewModel = new UserViewModel
        {
            Id = Guid.NewGuid(),
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            PhoneNumber = string.Empty,
            BirthDay = default
        };

        _mockUserRepository.Setup(repo => repo.GetByIdAsync(userEntity.Id)).ReturnsAsync(userEntity);
        _mockMapper.Setup(mapper => mapper.Map<UserViewModel>(userEntity)).Returns(userViewModel);

        var result = userService.GetByIdAsync(userEntity.Id).Result;

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<UserViewModel>());
    }

    /// <summary>
    /// Тестирование метода Create. Создает пользователя на основе переданных данных и возвращает результат операции.
    /// </summary>
    [Test]
    public async Task Create_ValidModel_ReturnsIdentityResult()
    {
        var userService = new UserService(_mockUserRepository.Object, _mockMapper.Object);
        var createUserViewModel = new CreateUserViewModel
        {
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            PhoneNumber = string.Empty,
            Password = "VerySafePassword123",
            BirthDay = default,
        };

        var userEntity = new User
        {
            Id = Guid.NewGuid(),
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            PhoneNumber = string.Empty,
            BirthDay = default,
            RegisterDate = default
        };

        var identityResult = IdentityResult.Success;

        _mockMapper.Setup(mapper => mapper.Map<User>(createUserViewModel)).Returns(userEntity);
        _mockUserRepository.Setup(repo => repo.CreateAsync(userEntity, createUserViewModel.Password)).ReturnsAsync(identityResult);

        var result = await userService.Create(createUserViewModel, createUserViewModel.Password);

        Assert.That(result, Is.EqualTo(identityResult));
    }

    /// <summary>
    /// Тестирование метода Delete. Удаляет пользователя по идентификатору и возвращает результат операции.
    /// </summary>
    [Test]
    public async Task Delete_ExistingUserId_ReturnsIdentityResult()
    {
        var userService = new UserService(_mockUserRepository.Object, _mockMapper.Object);
        var userEntity = new User
        {
            Id = Guid.NewGuid(),
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            PhoneNumber = string.Empty,
            BirthDay = default,
            RegisterDate = default
        };

        var identityResult = IdentityResult.Success;

        _mockUserRepository.Setup(repo => repo.GetByIdAsync(userEntity.Id)).ReturnsAsync(userEntity);
        _mockUserRepository.Setup(repo => repo.DeleteAsync(userEntity)).ReturnsAsync(identityResult);

        var result = await userService.Delete(userEntity.Id);

        Assert.That(result, Is.EqualTo(identityResult));
    }

    /// <summary>
    /// Тестирование метода Update. Обновляет данные пользователя по идентификатору и возвращает результат операции.
    /// </summary>
    [Test]
    public async Task Update_ExistingUserIdAndValidModel_ReturnsIdentityResult()
    {
        var userService = new UserService(_mockUserRepository.Object, _mockMapper.Object);

        var updateUserViewModel = new UpdateUserViewModel
        {
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            PhoneNumber = string.Empty,
            Password = "NewVerySafePassword",
            BirthDay = default,
        };

        var existingUserEntity = new User
        {
            Id = Guid.NewGuid(),
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            PhoneNumber = string.Empty,
            BirthDay = default,
            RegisterDate = default
        };

        var identityResult = IdentityResult.Success;

        _mockUserRepository.Setup(repo => repo.GetByIdAsync(existingUserEntity.Id)).ReturnsAsync(existingUserEntity);
        _mockMapper.Setup(mapper => mapper.Map(updateUserViewModel, existingUserEntity)).Verifiable();
        _mockUserRepository.Setup(repo => repo.UpdateAsync(existingUserEntity)).ReturnsAsync(identityResult);

        var result = await userService.Update(existingUserEntity.Id, updateUserViewModel);

        Assert.That(result, Is.EqualTo(identityResult));
    }
}