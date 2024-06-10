using SocialNetwork.API.Interactions.Domain.Model.Commands;
using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Interactions.Domain.Services;
using SocialNetwork.API.Shared.Domain.Repositories;

namespace SocialNetwork.API.Interactions.Application.Internal.CommandServices;

public class StatusCommandService(IStatusRepository statusRepository, IUnitOfWork unitOfWork) : IStatusCommandService
{
    public async Task<Status> Handle(CreateStatusCommand command)
    {
        var status = await statusRepository.FindByUserAndMessageAsync(command.User, command.Message);
        if (status != null)
        {
            throw new Exception("Status already exists"); 
        }

        status = new Status(command);
        await  statusRepository.AddAsync(status);
        await unitOfWork.CompleteAsync();
        return status;

    }
} 