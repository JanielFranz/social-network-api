using SocialNetwork.API.Interactions.Domain.Model.Entities;

namespace SocialNetwork.API.Interactions.Interfaces.REST.Resources;
// Ojito con Network Status Identifier, GUID?
public record StatusResource(int Id, string message, string user);