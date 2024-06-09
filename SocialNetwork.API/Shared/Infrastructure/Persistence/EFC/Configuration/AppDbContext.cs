using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.API.Interactions.Domain.Model.ValueObjects;
using SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder) 
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors 
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Configuraciones de mis entities
        
        // Following Interaction
        builder.Entity<FollowingInteraction>().ToTable("FollowingInteractions");
        builder.Entity<FollowingInteraction>().HasKey(f => f.Id);
        builder.Entity<FollowingInteraction>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FollowingInteraction>().Property(f => f.Follower).IsRequired();
        builder.Entity<FollowingInteraction>().Property(f => f.Followed).IsRequired();
        
        
        // Aplicando snake case convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}    