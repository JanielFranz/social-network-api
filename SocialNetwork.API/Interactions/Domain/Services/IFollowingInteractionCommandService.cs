using SocialNetwork.API.Interactions.Domain.Model.Commands;
using SocialNetwork.API.Interactions.Domain.Model.ValueObjects;

namespace SocialNetwork.API.Interactions.Domain.Services;

public interface IFollowingInteractionCommandService
{
    Task<FollowingInteraction> Handle(CreateFollowingInteractionCommand command);
}