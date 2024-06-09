using SocialNetwork.API.Interactions.Domain.Model.Commands;

namespace SocialNetwork.API.Interactions.Domain.Model.Aggregates;

public class FollowingInteraction
{
    public int Id { get; private set; }
    public string From { get; private set; }
    public string To { get; private set; }

    protected FollowingInteraction()
    {
        this.From = string.Empty;
        this.To = string.Empty;
    }

    public FollowingInteraction(CreateFollowingInteractionCommand command)
    {
        this.From = command.From;
        this.To = command.To;
    }
}