using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.API.Interactions.Domain.Model.Entities;
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

        //Status
        builder.Entity<Status>().ToTable("UserStatus");
        builder.Entity<Status>().HasKey(s => s.StatusIdentifier);
        builder.Entity<Status>().Property(s => s.StatusIdentifier).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Status>().Property(s => s.User).IsRequired();
        builder.Entity<Status>().Property(s => s.Message).IsRequired();
        builder.Entity<Status>().Property(s => s.CreatedDate).ValueGeneratedOnAdd();
        // Aplicando snake case convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}    