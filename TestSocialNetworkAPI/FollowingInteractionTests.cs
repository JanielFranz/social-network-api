using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialNetwork.API.Interactions.Domain.Model.Entities;
using SocialNetwork.API.Interactions.Domain.Model.Queries;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Interactions.Domain.Services;
using SocialNetwork.API.Interactions.Interfaces.REST;
using SocialNetwork.API.Interactions.Interfaces.REST.Resources;

namespace TestSocialNetworkAPI;


public class FollowingInteractionTests
{
    [TestClass]
    public class StatusControllerTests
    {
        // Objetos que seran usados en el test
        private Mock<IFollowingInteractionRepository> _interactionRepoMock;
        private Fixture _fixture;
        private FollowingInteractionsController _controller;

        public StatusControllerTests()
        {
            _fixture = new Fixture();
            _interactionRepoMock = new Mock<IFollowingInteractionRepository>();
        }

        [TestMethod]
        public async Task Get_FollowingInteraction_ReturnsOk()
        {
            var follower = "testFollower";
            var followed = "testFollowed";
            var interaction = _fixture.Create<FollowingInteraction>();
            _interactionRepoMock.Setup(repo => repo.FindByFollowerAndFollowedAsync(follower, followed))
                .ReturnsAsync(interaction);

            var mockInteractionCommandService = new Mock<IFollowingInteractionCommandService>();
            var mockInteractionQueryService = new Mock<IFollowingInteractionQueryService>();
            mockInteractionQueryService
                .Setup(service => service.Handle(It.IsAny<GetFollowingInteractionByFollowerAndFollowedQuery>()))
                .ReturnsAsync(interaction);

            _controller = new FollowingInteractionsController(mockInteractionCommandService.Object,
                mockInteractionQueryService.Object);

      
            var result = await _controller.GetFollowingInteractionByFollowerAndFollowed(follower, followed);

        
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var returnedInteraction = okResult.Value as FollowingInteractionResource;
            Assert.IsNotNull(returnedInteraction);
            Assert.AreEqual(interaction.Follower, returnedInteraction.Follower);
            Assert.AreEqual(interaction.Followed, returnedInteraction.Followed);
        }


        [TestMethod]
        public async Task Get_AllFollowingInteractions_ReturnsOk()
        {

            var follower = "testFollower";
            var interactions = _fixture.CreateMany<FollowingInteraction>(3).ToList();
            _interactionRepoMock.Setup(repo => repo.FindAllByFollowerAsync(follower)).ReturnsAsync(interactions);

            var mockInteractionCommandService = new Mock<IFollowingInteractionCommandService>();
            var mockInteractionQueryService = new Mock<IFollowingInteractionQueryService>();
            mockInteractionQueryService.Setup(service => service.Handle(It.IsAny<GetAllFollowingInteractionByFollowerQuery>())).ReturnsAsync(interactions);

            _controller = new FollowingInteractionsController(mockInteractionCommandService.Object, mockInteractionQueryService.Object);
            
            var result = await _controller.GetAllFollowingInteractionByFollower(follower);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var returnedInteractions = okResult.Value as IEnumerable<FollowingInteractionResource>;
            Assert.AreEqual(3, returnedInteractions.Count());
        }

    }
}