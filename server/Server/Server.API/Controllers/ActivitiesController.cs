using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs;
using Server.Application.Features.Activity.Command;
using Server.Application.Features.Activity.Query;

namespace Server.API.Controllers;

public class ActivitiesController:BaseApiController
{

    [HttpGet()]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await Mediator.Send(new GetActivitiesListQuery()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityDto>> GetActivityById(string id)
    {
        var query = new GetActivityByIdQuery(id);
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(CreateActivityDto dto)
    {
        return await Mediator.Send(new CreateActivity.Command(dto));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Unit>> UpdateActivity(string id, UpdateActivityDto dto)
    {
        return await Mediator.Send(new UpdateActivity.Command(id, dto));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> DeleteActivity(string id)
    {
        return await Mediator.Send(new DeleteActivity.Command(id));
    }
    
}