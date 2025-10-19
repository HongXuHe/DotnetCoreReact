using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Activity.Query;

namespace Server.API.Controllers;

public class ActivityController:BasicController
{
    private readonly ISender _sender;

    public ActivityController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await _sender.Send(new GetActivitiesListQuery()));
    }

    [HttpGet("{activityId}")]
    public async Task<IActionResult> GetActivityById(string activityId)
    {
        var query = new GetActivityByIdQuery(activityId);
        var activityDto = await _sender.Send(query);
        return activityDto==null? NotFound(): Ok(activityDto);
    }
}