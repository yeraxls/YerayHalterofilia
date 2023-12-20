using Microsoft.AspNetCore.Mvc;
using YerayHalterofilia.Models;
using YerayHalterofilia.Services;

namespace YerayHalterofilia.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserServices _userServices;
    private readonly IConfiguration _config;
    public UserController(ILogger<UserController> logger, IUserServices userServices, IConfiguration config)
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

                return Ok(token);
            }
            return NotFound("Usuario no encontrado");
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("/create-user")]
    public async Task<ActionResult> CreateUser([FromBody] UserModel login)
    {
        try
        {
            _userServices.CreateUser(login);
            return Ok("Usuario creado");
        }
        catch
        {
            return BadRequest();
        }
    }
}
