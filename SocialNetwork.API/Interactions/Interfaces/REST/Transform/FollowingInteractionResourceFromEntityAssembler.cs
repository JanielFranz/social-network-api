using SocialNetwork.API.Interactions.Domain.Model.ValueObjects;
using SocialNetwork.API.Interactions.Interfaces.REST.Resources;

namespace SocialNetwork.API.Interactions.Interfaces.REST.Transform;

public static class FollowingInteractionResourceFromEntityAssembler
{
    public static FollowingInteractionResource ToResourceFromEntity(FollowingInteraction entity)
    {
        return new FollowingInteractionResource(entity.Id, entity.Follower, entity.Followed);
    }
}