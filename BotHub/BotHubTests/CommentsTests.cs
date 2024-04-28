using Application.Services;
using Application.ViewModels.CommentViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace BotHubTests;

public class CommentsTests
{
    private Guid _commentId;
    private CommentService _commentService;
    private Mock<IRepository<Comment, Guid>> _mockCommentRepository;
    private Mock<IMapper> _mockMapper;
    private Mock<IRepository<Post, Guid>> _mockPostRepository;
    private Mock<IUserRepository> _mockUserRepository;

    [SetUp]
    public void Setup()
    {
        _mockCommentRepository = new Mock<IRepository<Comment, Guid>>();
        _mockPostRepository = new Mock<IRepository<Post, Guid>>();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();
        _commentService = new CommentService(_mockUserRepository.Object, _mockCommentRepository.Object,
            _mockPostRepository.Object, _mockMapper.Object);
        _commentId = Guid.NewGuid();
    }

    [Test]
    public async Task GetAllAsync_ReturnsListOfCommentViewModels()
    {
        var comments = new List<Comment>();
        _mockCommentRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(comments);
        _mockMapper.Setup(m => m.Map<IList<CommentViewModel>>(comments)).Returns(new List<CommentViewModel>());

        var result = await _commentService.GetAllAsync();

        result.Should().NotBeNull().And.BeEmpty();
    }

    [Test]
    public async Task GetByIdAsync_ReturnsPostViewModel()
    {
        var comment = CreateSampleComment();
        var commentViewModel = CreateSampleCommentViewModel();

        _mockCommentRepository.Setup(repository => repository.GetByIdAsync(_commentId)).ReturnsAsync(comment);
        _mockMapper.Setup(m => m.Map<CommentViewModel>(comment)).Returns(commentViewModel);

        var result = await _commentService.GetByIdAsync(_commentId);

        result.Should().NotBeNull();
        result.Id.Should().Be(_commentId);
        result.Text.Should().Be("Text");
    }

    private Comment CreateSampleComment()
    {
        return new Comment
        {
            Id = _commentId,
            Text = "Text",
            LikesAmount = 0,
            DislikesAmount = 0,
            CreationDate = default,
            AuthorId = default!,
            PostId = default
        };
    }

    private CommentViewModel CreateSampleCommentViewModel()
    {
        return new CommentViewModel
        {
            Id = _commentId,
            Text = "Text",
            LikesAmount = 0,
            DislikesAmount = 0,
            CreationDate = default,
            AuthorId = default!,
            PostId = default
        };
    }
}