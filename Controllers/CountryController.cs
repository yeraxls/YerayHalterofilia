using Microsoft.AspNetCore.Mvc;
using YerayHalterofilia.Models;
using YerayHalterofilia.Services;

namespace YerayHalterofilia.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{

    private readonly ILogger<CountryController> _logger;
    private readonly ICountryServices _countryServices;

    public CountryController(ILogger<CountryController> logger, ICountryServices countryServices)
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
            return BadRequest();
        }
    }

    [HttpPost("/{name}/{cod}")]
    public async Task<ActionResult> CreateCountry(string name, string cod)
    {
        try
        {
            await _countryServices.CreateCountry(name, cod);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut()]
    public async Task<ActionResult> UpdateTypeLifting([FromBody] CountryModel country)
    {
        try
        {
            await _countryServices.UpdateCountry(country);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCountry(int id)
    {
        try
        {
            await _countryServices.DeleteCountry(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
