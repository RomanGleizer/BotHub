using Application.Interfaces;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BotHub.Server.Controllers;

/// <summary>
/// Контроллер для управления действиями с пользователями через API.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService, ILogger<UsersController> logger) : ControllerBase
{
    private readonly ILogger<UsersController> _logger = logger;
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Инициализирует новый экземпляр контроллера пользователей.
    /// </summary>
    /// <param name="userService">Сервис пользователей.</param>
    [HttpGet]
    [ProducesResponseType<IList<UserViewModel>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get users");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Получает всех пользователей асинхронно.
    /// </summary>
    /// <returns>Список всех пользователей.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType<UserViewModel>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid id)
    {
        try 
        {
            var result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get user");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Получает пользователя по указанному идентификатору асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <returns>Пользователь с указанным идентификатором.</returns>
    [HttpPost]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] CreateUserViewModel model)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);

        try
        {
            var result = await _userService.Create(model, model.Password);
            return CreatedAtAction(nameof(Get), result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add user");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Создает нового пользователя асинхронно.
    /// </summary>
    /// <param name="model">Модель представления создаваемого пользователя.</param>
    /// <returns>Результат операции создания пользователя.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserViewModel model)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);

        try
        {
            var result = await _userService.Update(id, model);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update user");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Обновляет информацию о пользователе по указанному идентификатору асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="model">Модель представления обновляемого пользователя.</param>
    /// <returns>Результат операции обновления информации о пользователе.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete user");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
