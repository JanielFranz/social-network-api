using SocialNetwork.API.Interactions.Domain.Model.Aggregates;
using SocialNetwork.API.Interactions.Domain.Model.Commands;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Interactions.Domain.Services;
using SocialNetwork.API.Shared.Domain.Repositories;

namespace SocialNetwork.API.Interactions.Application.Internal.CommandServices;

public class FollowingInteractionCommandService : IFollowingInteractionCommandService
{
    private readonly IFollowingInteractionRepository _followingInteractionRepository;
    private readonly IUnitOfWork _unitOfWork;
    public FollowingInteractionCommandService(IFollowingInteractionRepository followingInteractionRepository, IUnitOfWork unitOfWork)
    {
        _followingInteractionRepository = followingInteractionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FollowingInteraction> Handle(CreateFollowingInteractionCommand command)
    {
        var followingInteraction =
            await _followingInteractionRepository.FindByFollowerAndFollowedAsync(command.Follower, command.Followed);
        if (followingInteraction != null)
            throw new Exception("Following interaction already exists");
        followingInteraction = new FollowingInteraction(command);
        await _followingInteractionRepository.AddAsync(followingInteraction);
        await _unitOfWork.CompleteAsync();
        return followingInteraction;

    }
}