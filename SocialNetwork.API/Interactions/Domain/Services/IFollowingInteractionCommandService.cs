using SocialNetwork.API.Interactions.Domain.Model.Aggregates;
using SocialNetwork.API.Interactions.Domain.Model.Commands;

namespace SocialNetwork.API.Interactions.Domain.Services;

public interface IFollowingInteractionCommandService
{
    Task<FollowingInteraction> Handle(CreateFollowingInteractionCommand command);
}