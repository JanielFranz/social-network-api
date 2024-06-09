namespace SocialNetwork.API.Interactions.Domain.Model.Queries;

public record GetFollowingInteractionByFollowerAndFollowedQuery(string Follower, string Followed);