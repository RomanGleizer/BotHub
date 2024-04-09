using Application.Interfaces;
using Application.ViewModels.CommentViewModels;
using Application.ViewModels.PostViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BotHub.Server.Controllers;

/// <summary>
///     Контроллер для управления комментариями.
/// </summary>
/// <remarks>
///     Конструктор для CommentsController.
/// </remarks>
/// <param name="commentService">Сервис комментариев.</param>
/// <param name="logger">Логгер.</param>
[Route("api/[controller]")]
[ApiController]
public class CommentsController(ICommentService commentService, ILogger<CommentsController> logger)
    : ControllerBase
{
    /// <summary>
    ///     Получает все комментарии.
    /// </summary>
    /// <returns>Коллекция комментариев.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IList<CommentViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await commentService.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Произошла ошибка при получении комментариев");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    ///     Получает комментарий по его ID.
    /// </summary>
    /// <param name="id">ID комментария для получения.</param>
    /// <returns>Комментарий с указанным ID.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CommentViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var result = await commentService.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Произошла ошибка при получении комментария с ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    ///     Создает новый комментарий.
    /// </summary>
    /// <param name="model">Данные для нового комментария.</param>
    /// <returns>Новый созданный комментарий.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CommentViewModel), StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] CreateCommentViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await commentService.CreateAsync(model);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Произошла ошибка при создании комментария");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    ///     Обновляет существующий комментарий.
    /// </summary>
    /// <param name="id">ID комментария для обновления.</param>
    /// <param name="model">Обновленные данные для комментария.</param>
    /// <returns>Обновленный комментарий.</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCommentViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await commentService.UpdateAsync(id, model);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Произошла ошибка при обновлении комментария с ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    ///     Удаляет комментарий.
    /// </summary>
    /// <param name="id">ID комментария для удаления.</param>
    /// <returns>Результат операции удаления.</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var result = await commentService.DeleteAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Произошла ошибка при удалении комментария с ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}