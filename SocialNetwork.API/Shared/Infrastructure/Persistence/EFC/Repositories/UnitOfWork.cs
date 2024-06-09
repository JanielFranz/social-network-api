using SocialNetwork.API.Shared.Domain.Repositories;
using SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}