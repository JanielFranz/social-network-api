using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Shared.Domain.Repositories;

namespace SocialNetwork.API.Interactions.Domain.Repositories;

public interface IFollowingInteractionRepository : IBaseRepository<FollowingInteraction>
{
    Task<IEnumerable<FollowingInteraction>> FindAllByFollowerAsync(string follower);
    Task<IEnumerable<FollowingInteraction>> FindAllByFollowedAsync(string followed);
    Task<FollowingInteraction> FindByFollowerAndFollowedAsync(string follower, string followed);
}