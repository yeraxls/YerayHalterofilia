using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YerayHalterofilia.Models;
using YerayHalterofilia.Services;

namespace YerayHalterofilia.Controllers;

[ApiController]
[Route("[controller]")]
public class LiftingsWeightController : ControllerBase
{

    private readonly ILoggerSistemService _logger;
    private readonly ILiftingWeightServices _liftingWeightServices;

    public LiftingsWeightController(ILoggerSistemService logger, ILiftingWeightServices liftingWeightServices)
    {
        _logger = logger;
        _liftingWeightServices = liftingWeightServices;
    }

    [HttpGet()]
    public async Task<ActionResult> Get()
    {
        try
        {
            return Ok(await _liftingWeightServices.GetLiftingWeights());
        }
        catch
        {
            _logger.Write("Get", "Lifting Weight", true);
            return BadRequest();
        }
    }

    [HttpGet("/get-by-id-type/{id}")]
    [Authorize]
    public async Task<ActionResult> GetByIdType(int id)
    {
        try
        {
            return Ok(await _liftingWeightServices.GetCompetitorByIdType(id));
        }
        catch
        {
            _logger.Write("Get", "Lifting Weight by Id", true);
            return BadRequest();
        }
    }
    [HttpGet("/get-by-competitor/{idCompetitor}")]
    [Authorize]
    public async Task<ActionResult> GetLiftingWeightByIdCompetitor(int idCompetitor)
    {
        try
        {
            return Ok(await _liftingWeightServices.GetLiftingWeightByIdCompetitor(idCompetitor));
        }
        catch
        {
            _logger.Write("Get", "Lifting Weight by Id Competitor", true);
            return BadRequest();
        }
    }

    [HttpPost()]
    [Authorize]
    public async Task<ActionResult> CreateLiftingsWeight([FromBody] NewLiftingWeightModel newLiftingWeight)
    {
        try
        {
            await _liftingWeightServices.CreateLiftingWeight(newLiftingWeight);
            _logger.Write("Post", "Created Lifting Weight");
            return Ok();
        }
        catch
        {
            _logger.Write("Post", "Lifting Weight", true);
            return BadRequest();
        }
    }

    [HttpPut()]
    [Authorize]
    public async Task<ActionResult> UpdateLiftingsWeight([FromBody] LiftingsWeightModel liftingsWeight)
    {
        try
        {
            await _liftingWeightServices.UpdateLiftingWeight(liftingsWeight);
            _logger.Write("Put", "Updated Lifting Weight");
            return Ok();
        }
        catch
        {
            _logger.Write("Put", "Lifting Weight", true);
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteLiftingsWeight(int id)
    {
        try
        {
            await _liftingWeightServices.DeleteLiftingWeight(id);
            _logger.Write("Delete", "Deleted Lifting Weight");
            return Ok();
        }
        catch
        {
            _logger.Write("Delete", "Lifting Weight", true);
            return BadRequest();
        }
    }
}
