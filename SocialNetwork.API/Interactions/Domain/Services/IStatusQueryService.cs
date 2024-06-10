using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Interactions.Domain.Model.Queries;

namespace SocialNetwork.API.Interactions.Domain.Services;

public interface IStatusQueryService
{
    Task<IEnumerable<Status>> Handle(GetAllStatusByUserQuery query);
    Task<Status> Handle(GetStatusByUserAndMessageQuery query);
}