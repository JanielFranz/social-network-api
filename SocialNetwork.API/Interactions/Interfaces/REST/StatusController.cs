using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Interactions.Domain.Model.Queries;
using SocialNetwork.API.Interactions.Domain.Services;
using SocialNetwork.API.Interactions.Interfaces.REST.Resources;
using SocialNetwork.API.Interactions.Interfaces.REST.Transform;

namespace SocialNetwork.API.Interactions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]


public class StatusController(IStatusCommandService statusCommandService, IStatusQueryService statusQueryService) : ControllerBase
{
    
    [HttpPost]
    public async Task<ActionResult> CreateStatus([FromBody] CreateStatusResource resource)
    {
        var createStatusCommand = CreateStatusCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await statusCommandService.Handle(createStatusCommand);
        return CreatedAtAction(nameof(GetStatusByUserAndMessage), new { user = result.User, message = result.Message },
            StatusResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{user}")]
    public async Task<ActionResult> GetAllStatusByUser(string user)
    {
        var getAllStatusByUserQuery = new GetAllStatusByUserQuery(user);
        var result = await statusQueryService.Handle(getAllStatusByUserQuery);
        var resources = result.Select(StatusResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet("{user}/{message}" )]
    public async Task<ActionResult> GetStatusByUserAndMessage(string user, string message)
    {
        var getStatusByUserAndMessageQuery = new GetStatusByUserAndMessageQuery(user, message);
        var result = await statusQueryService.Handle(getStatusByUserAndMessageQuery);
        var resource = StatusResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}