using Application.Services;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace BotHubTests;

public class UserServiceTests
{
    private Mock<IMapper> _mockMapper;
    private Mock<SignInManager<User>> _mockSignInManager;
    private Mock<UserManager<User>> _mockUserManager;
    private Mock<IUserRepository> _mockUserRepository;
    private string _userId;
    private UserService _userService;

    [SetUp]
    public void Setup()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();
        _userId = Guid.NewGuid().ToString();

        _mockUserManager = new Mock<UserManager<User>>(
            Mock.Of<IUserStore<User>>(),
            null!,
            null!,
            null!,
            null!,
            null!,
            null!,
            null!,
            null!);

        _mockSignInManager = new Mock<SignInManager<User>>(
            _mockUserManager.Object,
            Mock.Of<IHttpContextAccessor>(),
            Mock.Of<IUserClaimsPrincipalFactory<User>>(),
            null!,
            null!,
            null!,
            null!);

        _userService = new UserService(_mockUserRepository.Object, _mockMapper.Object, _mockSignInManager.Object);
    }

    [Test]
    public async Task GetAllAsync_ReturnsListOfUserViewModels()
    {
        var users = new List<User>();

        _mockUserRepository.Setup(userRepository => userRepository.GetAllAsync()).ReturnsAsync(users);
        _mockMapper.Setup(mapper => mapper.Map<IList<UserViewModel>>(users)).Returns([]);

        var result = await _userService.GetAllAsync();

        result.Should().NotBeNull().And.BeEmpty();
    }

    [Test]
    public async Task GetByIdAsync_ReturnsUserViewModel()
    {
        var user = CreateSampleUser();
        var userViewModel = CreateSampleUserViewModel();

        _mockUserRepository.Setup(userRepository => userRepository.GetByIdAsync(_userId)).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<UserViewModel>(user)).Returns(userViewModel);

        var result = await _userService.GetByIdAsync(_userId);

        result.Should().NotBeNull();
        result.Id.Should().Be(_userId);
        result.Email.Should().Be("test@example.com");
    }

    [Test]
    public async Task RegisterAsync_ReturnsIdentityResult()
    {
        var identityResult = IdentityResult.Success;
        var user = CreateSampleUser();
        var userViewModel = CreateSampleUserViewModel();
        var registerViewModel = new RegisterViewModel
        {
            Email = "test@example.com",
            Password = "Password123",
            RepeatedPassword = "Password123",
            Login = null!
        };

        _mockUserRepository.Setup(userRepository => userRepository
                .CreateAsync(It.IsAny<User>(), registerViewModel.Password))
            .ReturnsAsync(identityResult);

        _mockMapper.Setup(mapper => mapper.Map<UserViewModel>(user)).Returns(userViewModel);

        var result = await _userService.RegisterAsync(registerViewModel, registerViewModel.Password);

        result.Should().NotBeNull();
        result.Succeeded.Should().Be(result.Succeeded);
    }

    [Test]
    public async Task DeleteAsync_ReturnsIdentityResult()
    {
        var identityResult = IdentityResult.Success;
        var user = CreateSampleUser();

        _mockUserRepository.Setup(userRepository => userRepository.GetByIdAsync(_userId)).ReturnsAsync(user);
        _mockUserRepository.Setup(userRepository => userRepository.DeleteAsync(user)).ReturnsAsync(identityResult);

        var result = await _userService.DeleteAsync(_userId);

        result.Should().NotBeNull();
        result.Succeeded.Should().Be(result.Succeeded);
    }

    [Test]
    public async Task UpdateAsync_ReturnsIdentityResult()
    {
        var identityResult = IdentityResult.Success;
        var user = CreateSampleUser();
        var updateUserModel = new UpdateUserViewModel
        {
            Email = "updated@example.com",
            Login = null!
        };

        _mockUserRepository.Setup(userRepository => userRepository.GetByIdAsync(_userId)).ReturnsAsync(user);
        _mockUserRepository.Setup(userRepository => userRepository.UpdateAsync(user)).ReturnsAsync(identityResult);

        var result = await _userService.UpdateAsync(_userId, updateUserModel);

        result.Should().NotBeNull();
        result.Succeeded.Should().Be(result.Succeeded);
    }

    [Test]
    public async Task GetAllAsync_ReturnsListOfUserViewModels_EmptyList()
    {
        var userService = new UserService(_mockUserRepository.Object, _mockMapper.Object, _mockSignInManager.Object);

        _mockUserRepository.Setup(userRepository => userRepository.GetAllAsync()).ReturnsAsync([]);
        _mockMapper.Setup(mapper => mapper.Map<IList<UserViewModel>>(It.IsAny<List<User>>())).Returns([]);

        var result = await userService.GetAllAsync();

        result.Should().NotBeNull().And.BeEmpty();
    }

    private User CreateSampleUser()
    {
        return new User
        {
            Id = _userId,
            Email = "test@example.com",
            PostIds = null!,
            CommentIds = null!,
            Login = null!
        };
    }

    private UserViewModel CreateSampleUserViewModel()
    {
        return new UserViewModel
        {
            Id = _userId,
            Email = "test@example.com",
            PostIds = null!,
            CommentIds = null!,
            Login = null!
        };
    }
}