using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Interactions.Domain.Model.Queries;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Interactions.Domain.Services;

namespace SocialNetwork.API.Interactions.Application.Internal.QueryServices;

public class StatusQueryService(IStatusRepository statusRepository) : IStatusQueryService
{
    public async Task<IEnumerable<Status>> Handle(GetAllStatusByUserQuery query)
    {
        return await statusRepository.FindAllByUserAsync(query.user);
    }

    public async Task<Status> Handle(GetStatusByUserAndMessageQuery query)
    {
        return await statusRepository.FindByUserAndMessageAsync(query.user, query.Message);
    }
}