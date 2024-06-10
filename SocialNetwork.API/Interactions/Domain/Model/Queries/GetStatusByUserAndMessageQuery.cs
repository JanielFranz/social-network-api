using SocialNetwork.API.Interactions.Domain.Model.Entities;

namespace SocialNetwork.API.Interactions.Domain.Model.Queries;

public record GetStatusByUserAndMessageQuery(string user, string Message);
