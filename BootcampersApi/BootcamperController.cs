using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BootcampersApi {


[ApiController]
[Route("[controller]s")]
public class BootcamperController : ControllerBase
{
    private readonly IBootcamperRepository _bootcamperRepository;

    public BootcamperController(IBootcamperRepository bootcamperRepository)
    {
        _bootcamperRepository = bootcamperRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBootcampers(string search, int limit = 100, int page = 1)
    {
        if (search != null)
        {
            return Ok(await _bootcamperRepository.Search(search, limit, page));
        }
        return Ok(await _bootcamperRepository.GetAll(limit, page));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBootcamper(int id)
    {
        return Ok(await _bootcamperRepository.GetOne(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBootcamper(int id, [FromBody] Bootcamper bootcamper)
    {
        bootcamper.Id = id;
        return Ok(await _bootcamperRepository.Update(bootcamper));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBootcamper([FromBody] Bootcamper bootcamper)
    {
        var newCamper = await _bootcamperRepository.Insert(bootcamper);
        return Created($"/bootcampers/{newCamper.Id}", newCamper);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBootcamper(int id)
    {
        await _bootcamperRepository.Delete(id);
        return Ok();
    }


}


}