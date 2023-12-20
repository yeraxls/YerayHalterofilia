using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YerayHalterofilia.Models;
using YerayHalterofilia.Services;

namespace YerayHalterofilia.Controllers;

[ApiController]
[Route("[controller]")]
public class CompetitorController : ControllerBase
{

    private readonly ILogger<CompetitorController> _logger;
    private readonly ICompetitorServices _competitorServices;

    public CompetitorController(ILogger<CompetitorController> logger, ICompetitorServices competitorServices)
    {
        _logger = logger;
        _competitorServices = competitorServices;
    }

    [HttpGet()]
    [Authorize]
    public async Task<ActionResult> Get()
    {
        try
        {
            return Ok(await _competitorServices.GetCompetitors());
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("/get-by-id/{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _competitorServices.GetCompetitorById(id));
        }
        catch
        {
            return BadRequest();
        }
    }
    [HttpGet("/get-by-country/{idCountry}")]
    public async Task<ActionResult> GetByIdCountry(int idCountry)
    {
        try
        {
            return Ok(await _competitorServices.GetCompetitorByIdCountry(idCountry));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost()]
    public async Task<ActionResult> CreateCompetitor([FromBody] NewCompetitorModel competitor)
    {
        try
        {
            await _competitorServices.CreateCompetitor(competitor);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut()]
    public async Task<ActionResult> UpdateCompetitor([FromBody] CompetitorModel competitor)
    {
        try
        {
            await _competitorServices.UpdateCompetitor(competitor);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCompetitor(int id)
    {
        try
        {
            await _competitorServices.DeleteCompetitor(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
