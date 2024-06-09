using SocialNetwork.API.Interactions.Domain.Model.Commands;

namespace SocialNetwork.API.Interactions.Domain.Model.Aggregates;

public class FollowingInteraction
{
    public int Id { get; private set; }
    public string Follower { get; private set; }
    public string Followed { get; private set; }

    protected FollowingInteraction()
    {
        this.Follower = string.Empty;
        this.Followed = string.Empty;
    }

    public FollowingInteraction(CreateFollowingInteractionCommand command)
    {
        this.Follower = command.Follower;
        this.Followed = command.Followed;
    }
}