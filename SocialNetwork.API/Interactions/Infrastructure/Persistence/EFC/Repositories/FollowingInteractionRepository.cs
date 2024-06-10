using Microsoft.EntityFrameworkCore;
using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SocialNetwork.API.Interactions.Infrastructure.Persistence.EFC.Repositories;

public class FollowingInteractionRepository(AppDbContext context) : BaseRepository<FollowingInteraction>(context), IFollowingInteractionRepository
{
    public async Task<IEnumerable<FollowingInteraction>> FindAllByFollowerAsync(string follower)
    {
        return await Context.Set<FollowingInteraction>().Where(f => f.Follower == follower).ToListAsync();
    }

    public async Task<IEnumerable<FollowingInteraction>> FindAllByFollowedAsync(string followed)
    {
        return await Context.Set<FollowingInteraction>().Where((f => f.Followed == followed)).ToListAsync();
    }

    public async Task<FollowingInteraction> FindByFollowerAndFollowedAsync(string follower, string followed)
    {
        return await Context.Set<FollowingInteraction>().FirstOrDefaultAsync(f => f.Follower == follower &&
            f.Followed == followed);
    }
}