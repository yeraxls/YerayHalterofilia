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

    private readonly ILoggerSistemService _logger;
    private readonly ITypeLiftingServices _typeLiftingServices;

    public TypeLiftingController(ILoggerSistemService logger, ITypeLiftingServices typeLiftingServices)
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
            _logger.Write("Get", "Type Lifting", true);
            return BadRequest();
        }
    }

    [HttpPost("/{type}")]
    public async Task<ActionResult> CreateTypeLifting(string type)
    {
        try
        {
            await _typeLiftingServices.CreateTypeLifting(type);
            _logger.Write("Post", "Created Type lifting");
            return Ok();
        }
        catch
        {
            _logger.Write("Post", "Type Lifting", true);
            return BadRequest();
        }
    }

    [HttpPut()]
    public async Task<ActionResult> UpdateTypeLifting([FromBody] TypeLiftingModel typeLifting)
    {
        try
        {
            await _typeLiftingServices.UpdateTypeLifting(typeLifting);
            _logger.Write("Put", "Updated Type lifting");
            return Ok();
        }
        catch
        {
            _logger.Write("Put", "Type Lifting", true);
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTypeLifting(int id)
    {
        try
        {
            await _typeLiftingServices.DeleteTypeLifting(id);
            _logger.Write("Delete", "Deleted Type lifting");
            return Ok();
        }
        catch
        {
            _logger.Write("Delete", "Type Lifting", true);
            return BadRequest();
        }
    }
}
