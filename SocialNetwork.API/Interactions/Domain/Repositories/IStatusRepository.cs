using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Shared.Domain.Repositories;

namespace SocialNetwork.API.Interactions.Domain.Repositories;

public interface IStatusRepository : IBaseRepository<Status>
{
    Task<IEnumerable<Status>> FindAllByUserAsync(string user);
    Task<Status> FindByUserAndMessageAsync(string user, string message);
}