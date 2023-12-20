using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YerayHalterofilia.Models;
using YerayHalterofilia.Services;

namespace YerayHalterofilia.Controllers;

[ApiController]
[Route("[controller]")]
public class CompetitorController : ControllerBase
{

    private readonly ILoggerSistemService _logger;
    private readonly ICompetitorServices _competitorServices;

    public CompetitorController(ILoggerSistemService logger, ICompetitorServices competitorServices)
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
            _logger.Write("Get", "Competitor", true);
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
            _logger.Write("Get", "Competitor by Id", true);
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
            _logger.Write("Get", "Competitor by Id Country", true);
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
            _logger.Write("Post", "Competitor", true);
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
            _logger.Write("Put", "Competitor", true);
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
            _logger.Write("Delete", "Competitor", true);
            return BadRequest();
        }
    }
}
