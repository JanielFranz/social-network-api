using SocialNetwork.API.Interactions.Domain.Model.Aggregates;
using SocialNetwork.API.Interactions.Interfaces.Resources;

namespace SocialNetwork.API.Interactions.Interfaces.Transform;

public static class FollowingInteractionResourceFromEntityAssembler
{
    public static FollowingInteractionResource ToResourceFromEntity(FollowingInteraction entity)
    {
        return new FollowingInteractionResource(entity.Id, entity.Follower, entity.Followed);
    }
}