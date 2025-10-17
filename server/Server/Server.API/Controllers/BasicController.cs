using Microsoft.AspNetCore.Mvc;

namespace Server.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasicController:ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("test111");
    }
}