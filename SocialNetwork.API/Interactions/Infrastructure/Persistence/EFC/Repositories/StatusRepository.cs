using Microsoft.EntityFrameworkCore;
using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SocialNetwork.API.Interactions.Infrastructure.Persistence.EFC.Repositories;

public class StatusRepository(AppDbContext context) : BaseRepository<Status>(context), IStatusRepository
{
    public async Task<IEnumerable<Status>> FindAllByUserAsync(string user)
    {
        return await Context.Set<Status>().Where(s => s.User == user).ToListAsync();
    }




    public async Task<Status> FindByUserAndMessageAsync(string user, string message)
    {
        return await Context.Set<Status>().FirstOrDefaultAsync(f => f.User == user && f.Message == message);
    }
}