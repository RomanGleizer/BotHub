using Application.Interfaces;
using Application.ViewModels.PostViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BotHub.Server.Controllers;

/// <summary>
/// Контроллер для управления постами.
/// </summary>
/// <remarks>
/// Конструктор для PostsController.
/// </remarks>
/// <param name="postService">Сервис постов.</param>
/// <param name="logger">Логгер.</param>
[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService postService, ILogger<PostsController> logger) : ControllerBase
{
    /// <summary>
    /// Получает все посты.
    /// </summary>
    /// <returns>Коллекция постов.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IList<PostViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await postService.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Возникла ошибка при получении постов");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Получает пост по его ID.
    /// </summary>
    /// <param name="id">ID поста для получения.</param>
    /// <returns>Пост с указанным ID.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var result = await postService.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Возникла ошибка при получении поста с ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Создает новый пост.
    /// </summary>
    /// <param name="model">Данные для нового поста.</param>
    /// <returns>Новый созданный пост.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] CreatePostViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await postService.CreateAsync(model);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Возникла ошибка при создании поста");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Обновляет существующий пост.
    /// </summary>
    /// <param name="id">ID поста для обновления.</param>
    /// <param name="model">Обновленные данные для поста.</param>
    /// <returns>Обновленный пост.</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePostViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await postService.UpdateAsync(id, model);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Возникла ошибка при обновлении поста с ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Удаляет пост.
    /// </summary>
    /// <param name="id">ID поста для удаления.</param>
    /// <returns>Результат операции удаления.</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var result = await postService.DeleteAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Возникла ошибка при удалении поста с ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
