using SocialNetwork.API.Interactions.Domain.Model.Commands;
using SocialNetwork.API.Interactions.Interfaces.REST.Resources;

namespace SocialNetwork.API.Interactions.Interfaces.REST.Transform;

public static class CreateStatusCommandFromResourceAssembler
{
    public static CreateStatusCommand ToCommandFromResource(CreateStatusResource resource)
    {
        return new CreateStatusCommand(resource.Message, resource.User);
    }
}