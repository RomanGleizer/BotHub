using Application.Services;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace UserFunctionalTesting;

/// <summary>
/// ����� ���������������� �������������.
/// </summary>
[TestFixture]
public class UserServiceTests
{
    /// <summary>
    /// ��� ����������� �������������.
    /// </summary>
    private Mock<IUserRepository> _mockUserRepository;

    /// <summary>
    /// ��� IMapper.
    /// </summary>
    private Mock<IMapper> _mockMapper;

    /// <summary>
    /// ���������� �������� ����� ����� ����������� ������� �����.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();
    }

    /// <summary>
    /// ������������ ������ GetAllAsync. ���������� ������ ������� ������������� �������������.
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
    /// ������������ ������ GetByIdAsync. ���������� ������ ������������� ������������ �� ��� ��������������.
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
    /// ������������ ������ Create. ������� ������������ �� ������ ���������� ������ � ���������� ��������� ��������.
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
    /// ������������ ������ Delete. ������� ������������ �� �������������� � ���������� ��������� ��������.
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
    /// ������������ ������ Update. ��������� ������ ������������ �� �������������� � ���������� ��������� ��������.
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