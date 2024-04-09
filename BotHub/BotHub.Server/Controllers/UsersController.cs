using Application.Interfaces;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BotHub.Server.Controllers;

/// <summary>
///     Контроллер для управления пользователями.
/// </summary>
/// <remarks>
///     Конструктор для UsersController.
/// </remarks>
/// <param name="userService">Сервис пользователей.</param>
/// <param name="logger">Логгер.</param>
[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService<string> userService, ILogger<UsersController> logger)
    : ControllerBase
{
    /// <summary>
    ///     Получает всех пользователей.
    /// </summary>
    /// <returns>Коллекция пользователей.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IList<UserViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await userService.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Возникла ошибка при получении пользователей");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    ///     Получает пользователя по его ID.
    /// </summary>
    /// <param name="id">ID пользователя для получения.</param>
    /// <returns>Пользователь с указанным ID.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(string id)
    {
        try
        {
            var result = await userService.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Возникла ошибка при получении пользователя с ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    ///     Создает нового пользователя.
    /// </summary>
    /// <param name="model">Данные для нового пользователя.</param>
    /// <returns>Новый созданный пользователь.</returns>
    [HttpPost("register")]
    [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await userService.RegisterAsync(model, model.Password);
            await userService.SignInAsync(model.UserName, model.Password, true, true);
            return CreatedAtAction(nameof(Get), result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Возникла ошибка при создании пользователя");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    ///     Обновляет существующего пользователя.
    /// </summary>
    /// <param name="id">ID пользователя для обновления.</param>
    /// <param name="model">Обновленные данные для пользователя.</param>
    /// <returns>Обновленный пользователь.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(string id, [FromBody] UpdateUserViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await userService.UpdateAsync(id, model);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Возникла ошибка при обновлении пользователя с ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    ///     Удаляет пользователя.
    /// </summary>
    /// <param name="id">ID пользователя для удаления.</param>
    /// <returns>Результат операции удаления.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var result = await userService.DeleteAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Возникла ошибка при удалении пользователя с ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("signIn")]
    [ProducesResponseType(typeof(SignInResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> SignIn([FromBody] LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var signInResult = await userService.SignInAsync(
                model.UserName,
                model.Password,
                model.RememberMe,
                true);

            return Ok(signInResult);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Возникла ошибка при авторизации");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}