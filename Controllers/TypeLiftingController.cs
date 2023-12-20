using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YerayHalterofilia.Models;
using YerayHalterofilia.Services;

namespace YerayHalterofilia.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TypeLiftingController : ControllerBase
{

    private readonly ILogger<TypeLiftingController> _logger;
    private readonly ITypeLiftingServices _typeLiftingServices;

    public TypeLiftingController(ILogger<TypeLiftingController> logger, ITypeLiftingServices typeLiftingServices)
    {
        _logger = logger;
        _typeLiftingServices = typeLiftingServices;
    }

    [HttpGet()]
    public async Task<ActionResult> Get()
    {
        try
        {
            return Ok(await _typeLiftingServices.GetTypeLifting());
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("/{type}")]
    public async Task<ActionResult> CreateTypeLifting(string type)
    {
        try
        {
            await _typeLiftingServices.CreateTypeLifting(type);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut()]
    public async Task<ActionResult> UpdateTypeLifting([FromBody] TypeLiftingModel typeLifting)
    {
        try
        {
            await _typeLiftingServices.UpdateTypeLifting(typeLifting);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTypeLifting(int id)
    {
        try
        {
            await _typeLiftingServices.DeleteTypeLifting(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
