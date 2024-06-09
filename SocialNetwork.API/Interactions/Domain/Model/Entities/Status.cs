using System.ComponentModel.DataAnnotations.Schema;
using SocialNetwork.API.Interactions.Domain.Model.Commands;

namespace SocialNetwork.API.Interactions.Domain.Model.Entities;

public record Status
{
    public NetworkStatusIdentifier StatusIdentifier { get; private set; }
    
    // Los que envia en el request
    public string Message { get; private set; }
    public string User { get; private set; }
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }

    protected Status()
    {
        this.Message = string.Empty;
        this.User = string.Empty;
    }

    public Status(CreateStatusCommand command)
    {
        Message = command.Message;
        User = command.User;
    }
}