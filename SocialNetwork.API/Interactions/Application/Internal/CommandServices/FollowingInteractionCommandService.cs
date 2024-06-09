using SocialNetwork.API.Interactions.Domain.Model.Commands;
using SocialNetwork.API.Interactions.Domain.Model.ValueObjects;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Interactions.Domain.Services;
using SocialNetwork.API.Shared.Domain.Repositories;

namespace SocialNetwork.API.Interactions.Application.Internal.CommandServices;

public class FollowingInteractionCommandService(
    IFollowingInteractionRepository followingInteractionRepository,
    IUnitOfWork unitOfWork)
    : IFollowingInteractionCommandService
{
    // Creando el método Handle para la creación de una interacción de seguimiento
    public async Task<FollowingInteraction> Handle(CreateFollowingInteractionCommand command)
    {
        var followingInteraction =
            await followingInteractionRepository.FindByFollowerAndFollowedAsync(command.Follower, command.Followed);
        if (followingInteraction != null)
            throw new Exception("Following interaction already exists");
        followingInteraction = new FollowingInteraction(command);
        await followingInteractionRepository.AddAsync(followingInteraction);
        await unitOfWork.CompleteAsync();
        return followingInteraction;

    }
}