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
        return CreatedAtAction(nameof(GetAllStatusByUser), new { id = result.StatusIdentifier },
            StatusResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{account")]
    public async Task<ActionResult> GetAllStatusByUser(string account)
    {
        var getAllStatusByUserQuery = new GetAllStatusByUserQuery(account);
        var result = await statusQueryService.Handle(getAllStatusByUserQuery);
        var resources = result.Select(StatusResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}