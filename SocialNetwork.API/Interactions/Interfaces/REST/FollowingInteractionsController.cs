using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Interactions.Domain.Model.Commands;
using SocialNetwork.API.Interactions.Domain.Model.Queries;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Interactions.Domain.Services;
using SocialNetwork.API.Interactions.Interfaces.REST.Resources;
using SocialNetwork.API.Interactions.Interfaces.REST.Transform;

namespace SocialNetwork.API.Interactions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class FollowingInteractionsController(
    IFollowingInteractionCommandService followingInteractionCommandService,
    IFollowingInteractionQueryService followingInteractionQueryService)
    : ControllerBase
{
    // OJITO CON TODA ESTA PARTE
    [HttpPost]
    public async Task<ActionResult> CreateFollowingInteraction([FromBody] CreateFollowingInteractionResource resource)
    {
        var createFollowingSourceCommand =
            CreateFollowingInteractionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await followingInteractionCommandService.Handle(createFollowingSourceCommand);
        return  CreatedAtAction(nameof(GetFollowingInteractionByFollowerAndFollowed),
            new { follower = result.Follower, followed = result.Followed },
            FollowingInteractionResourceFromEntityAssembler.ToResourceFromEntity(result));

    }

    // GET exacto
    [HttpGet("{follower}/{followed}")]
    public async Task<ActionResult> GetFollowingInteractionByFollowerAndFollowed(string follower, string followed)
    {
        var getFollowingInteractionByFollowerAndFollowed =
            new GetFollowingInteractionByFollowerAndFollowedQuery(follower, followed);
        var result = await followingInteractionQueryService.Handle(getFollowingInteractionByFollowerAndFollowed);
        var resource = FollowingInteractionResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    
    
    // GET de  "todos"
    
    [HttpGet("follower/{follower}")]
    public async Task<ActionResult> GetAllFollowingInteractionByFollower(string follower)
    {
        var getAllFollowingInteractionByFollowerQuery = new GetAllFollowingInteractionByFollowerQuery(follower);
        var result = await followingInteractionQueryService.Handle(getAllFollowingInteractionByFollowerQuery);
        var resource = result.Select(FollowingInteractionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
    }

    [HttpGet("followed/{followed}")]
    public async Task<ActionResult> GetAllFollowedInteractionByFollower(string followed)
    {
        var getAllFollowingInteractionByFollowedQuery = new GetAllFollowingInteractionByFollowedQuery(followed);
        var result = await followingInteractionQueryService.Handle(getAllFollowingInteractionByFollowedQuery);
        var resource = result.Select(FollowingInteractionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
    }
    
    
    
}