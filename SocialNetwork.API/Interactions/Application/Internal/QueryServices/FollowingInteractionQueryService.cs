using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Interactions.Domain.Model.Queries;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Interactions.Domain.Services;
using SocialNetwork.API.Interactions.Infrastructure.Persistence.EFC.Repositories;

namespace SocialNetwork.API.Interactions.Application.Internal.QueryServices;

public class FollowingInteractionQueryService(IFollowingInteractionRepository followingInteractionRepository)
    : IFollowingInteractionQueryService
{
    public async Task<FollowingInteraction> Handle(GetFollowingInteractionByFollowerAndFollowedQuery query)
    {
        return await followingInteractionRepository.FindByFollowerAndFollowedAsync(query.Follower, query.Followed);
    }

    public async Task<IEnumerable<FollowingInteraction>> Handle(GetAllFollowingInteractionByFollowerQuery query)
    {
        return await followingInteractionRepository.FindAllByFollowerAsync(query.Follower);
    }

    public async Task<IEnumerable<FollowingInteraction>> Handle(GetAllFollowingInteractionByFollowedQuery query)
    {
        return await followingInteractionRepository.FindAllByFollowedAsync(query.Followed);
    }
}