using Microsoft.AspNetCore.Mvc;
using YerayHalterofilia.Models;
using YerayHalterofilia.Services;

namespace YerayHalterofilia.Controllers;

[ApiController]
[Route("[controller]")]
public class LiftingsWeightController : ControllerBase
{

    private readonly ILogger<LiftingsWeightController> _logger;
    private readonly ILiftingWeightServices _liftingWeightServices;

    public LiftingsWeightController(ILogger<LiftingsWeightController> logger, ILiftingWeightServices liftingWeightServices)
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
            return BadRequest();
        }
    }

    [HttpGet("/get-by-id-type/{id}")]
    public async Task<ActionResult> GetByIdType(int id)
    {
        try
        {
            return Ok(await _liftingWeightServices.GetCompetitorByIdType(id));
        }
        catch
        {
            return BadRequest();
        }
    }
    [HttpGet("/get-by-competitor/{idCompetitor}")]
    public async Task<ActionResult> GetLiftingWeightByIdCompetitor(int idCompetitor)
    {
        try
        {
            return Ok(await _liftingWeightServices.GetLiftingWeightByIdCompetitor(idCompetitor));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost()]
    public async Task<ActionResult> CreateLiftingsWeight([FromBody] NewLiftingWeightModel newLiftingWeight)
    {
        try
        {
            await _liftingWeightServices.CreateLiftingWeight(newLiftingWeight);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut()]
    public async Task<ActionResult> UpdateLiftingsWeight([FromBody] LiftingsWeightModel liftingsWeight)
    {
        try
        {
            await _liftingWeightServices.UpdateLiftingWeight(liftingsWeight);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLiftingsWeight(int id)
    {
        try
        {
            await _liftingWeightServices.DeleteLiftingWeight(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
