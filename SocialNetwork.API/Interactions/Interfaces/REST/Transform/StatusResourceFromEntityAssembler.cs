using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Interactions.Interfaces.REST.Resources;

namespace SocialNetwork.API.Interactions.Interfaces.REST.Transform;

public static class StatusResourceFromEntityAssembler
{
    public static StatusResource ToResourceFromEntity(Status entity)
    {
        return new StatusResource(entity.StatusIdentifier, entity.Message, entity.User, entity.CreatedDate);
    }
}