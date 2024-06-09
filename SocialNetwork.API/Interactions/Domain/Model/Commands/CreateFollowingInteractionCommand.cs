namespace SocialNetwork.API.Interactions.Domain.Model.Commands;

public record CreateFollowingInteractionCommand(string Follower, string Followed);