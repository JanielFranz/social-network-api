using SocialNetwork.API.Interactions.Domain.Model.Commands;
using SocialNetwork.API.Interactions.Interfaces.REST.Resources;

namespace SocialNetwork.API.Interactions.Interfaces.REST.Transform;

public static class CreateFollowingInteractionCommandFromResourceAssembler
{
    public static CreateFollowingInteractionCommand ToCommandFromResource(CreateFollowingInteractionResource resource)
    {
        return new CreateFollowingInteractionCommand(resource.Follower, resource.Followed);
    }
}