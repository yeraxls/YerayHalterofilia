using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YerayHalterofilia.Models;
using YerayHalterofilia.Services;

namespace YerayHalterofilia.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CountryController : ControllerBase
{

    private readonly ILoggerSistemService _logger;
    private readonly ICountryServices _countryServices;

    public CountryController(ILoggerSistemService logger, ICountryServices countryServices)
    {
        _logger = logger;
        _countryServices = countryServices;
    }

    [HttpGet()]
    public async Task<ActionResult> Get()
    {
        try
        {
            return Ok(await _countryServices.GetCountries());
        }
        catch
        {
            _logger.Write("Get", "Country", true);
            return BadRequest();
        }
    }

    [HttpPost("/{name}/{cod}")]
    public async Task<ActionResult> CreateCountry(string name, string cod)
    {
        try
        {
            await _countryServices.CreateCountry(name, cod);
            _logger.Write("Post", "Created country");
            return Ok();
        }
        catch
        {
            _logger.Write("Post", "Country", true);
            return BadRequest();
        }
    }

    [HttpPut()]
    public async Task<ActionResult> UpdateTypeLifting([FromBody] CountryModel country)
    {
        try
        {
            await _countryServices.UpdateCountry(country);
            _logger.Write("Put", "Updated country");
            return Ok();
        }
        catch
        {
            _logger.Write("Put", "Country", true);
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCountry(int id)
    {
        try
        {
            await _countryServices.DeleteCountry(id);
            _logger.Write("Delete", "Deleted country");
            return Ok();
        }
        catch
        {
            _logger.Write("Delete", "Country", true);
            return BadRequest();
        }
    }
}
