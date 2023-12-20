using Microsoft.AspNetCore.Mvc;
using YerayHalterofilia.Models;
using YerayHalterofilia.Services;

namespace YerayHalterofilia.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserServices _userServices;
    private readonly IConfiguration _config;
    private readonly ILoggerSistemService _logger;
    public UserController(ILoggerSistemService logger, IUserServices userServices, IConfiguration config)
    {
        _logger = logger;
        _userServices = userServices;
        _config = config;
    }

    [HttpPost()]
    public async Task<ActionResult> Login([FromBody] LoginModel login)
    {
        try
        {
            var user = await _userServices.Authenticate(login);
            if (user != null)
            {
                var token = _userServices.Generate(user);
                _logger.Write("Login", "Succesfull login");
                return Ok(token);
            }
            return NotFound("Usuario no encontrado");
        }
        catch
        {
            _logger.Write("Login", "Login error", true);
            return BadRequest();
        }
    }

    [HttpPost("/create-user")]
    public async Task<ActionResult> CreateUser([FromBody] UserModel login)
    {
        try
        {
            await _userServices.CreateUser(login);
            return Ok("Usuario creado");
        }
        catch
        {
            _logger.Write("Create user", "Create user", true);
            return BadRequest();
        }
    }
}
