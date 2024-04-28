using Application.Services;
using Application.ViewModels.PostViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace BotHubTests;

public class PostsServiceTests
{
    private Mock<IMapper> _mockMapper;
    private Mock<IRepository<Post, Guid>> _mockPostRepository;
    private Mock<IUserRepository> _mockUserRepository;
    private Guid _postId;
    private PostService _postService;

    [SetUp]
    public void Setup()
    {
        _mockPostRepository = new Mock<IRepository<Post, Guid>>();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();
        _postService = new PostService(_mockPostRepository.Object, _mockUserRepository.Object, _mockMapper.Object);
        _postId = Guid.NewGuid();
    }

    [Test]
    public async Task GetAllAsync_ReturnsListOfPostViewModels()
    {
        var posts = new List<Post>();
        _mockPostRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(posts);
        _mockMapper.Setup(m => m.Map<IList<PostViewModel>>(posts)).Returns(new List<PostViewModel>());

        var result = await _postService.GetAllAsync();

        result.Should().NotBeNull().And.BeEmpty();
    }

    [Test]
    public async Task GetByIdAsync_ReturnsPostViewModel()
    {
        var post = CreateSamplePost();
        var postViewModel = CreateSamplePostViewModel();

        _mockPostRepository.Setup(repository => repository.GetByIdAsync(_postId)).ReturnsAsync(post);
        _mockMapper.Setup(m => m.Map<PostViewModel>(post)).Returns(postViewModel);

        var result = await _postService.GetByIdAsync(_postId);

        result.Should().NotBeNull();
        result.Id.Should().Be(_postId);
        result.Title.Should().Be("Title");
    }

    private Post CreateSamplePost()
    {
        return new Post
        {
            Id = _postId,
            Title = "Title",
            ShortDescription = null!,
            FullDescription = null!,
            BotPossibilities = null!,
            BotLink = null!,
            BotImage = null!,
            CreationDate = default,
            LikesAmount = 0,
            DislikesAmount = 0,
            CommentIds = null!,
            AuthorId = default!
        };
    }

    private PostViewModel CreateSamplePostViewModel()
    {
        return new PostViewModel
        {
            Id = _postId,
            Title = "Title",
            ShortDescription = null!,
            FullDescription = null!,
            BotPossibilities = null!,
            BotLink = null!,
            BotImage = null!,
            CreationDate = default,
            LikesAmount = 0,
            DislikesAmount = 0,
            CommentIds = null!,
            AuthorId = default
        };
    }
}