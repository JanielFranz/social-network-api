using SocialNetwork.API.Interactions.Domain.Model.Queries;
using SocialNetwork.API.Interactions.Domain.Model.ValueObjects;

namespace SocialNetwork.API.Interactions.Domain.Services;

public interface IFollowingInteractionQueryService
{
    Task<FollowingInteraction> Handle(GetFollowingInteractionByFollowerAndFollowedQuery query);
    Task<IEnumerable<FollowingInteraction>> Handle(GetAllFollowingInteractionByFollowerQuery query);
    Task<IEnumerable<FollowingInteraction>> Handle(GetAllFollowingInteractionByFollowedQuery query);
}