using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace backend.Controllers
{

[ApiController]
[Route("api/externaldata")]
public class ExternalDataController : ControllerBase
{
    private readonly ExternalApiService _externalApiService;

    public ExternalDataController(ExternalApiService externalApiService)
    {
        _externalApiService = externalApiService;
    }

    [HttpGet]
    public async Task<IActionResult> GetExternalData()
    {
        try
        {
            var externalData = await _externalApiService.GetExternalApiData();
            return Ok(externalData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

}
