// public class RewardsServiceTests
// {
//     private readonly Mock<IRewardsRepository> _mockRepository;
//     private readonly RewardsService _service;

//     public RewardsServiceTests()
//     {
//         _mockRepository = new Mock<IRewardsRepository>();
//         _service = new RewardsService(_mockRepository.Object);
//     }

//     [Fact]
//     public async Task GetEligibleRewardsAsync_ShouldReturnRewards_WhenCustomerHasEligibleChannels()
//     {
//         var customer = new Customer
//         {
//             AccountNumber = "12345",
//             SubscribedChannels = new List<string> { "SPORTS", "MOVIES" }
//         };

//         var expectedRewards = new List<Reward>
//         {
//             new Reward { Channel = "SPORTS", RewardName = "CHAMPIONS_LEAGUE_FINAL_TICKET" },
//             new Reward { Channel = "MOVIES", RewardName = "PIRATES_OF_THE_CARIBBEAN_COLLECTION" }
//         };

//         _mockRepository.Setup(repo => repo.GetRewardsByChannelsAsync(customer.SubscribedChannels))
//                        .ReturnsAsync(expectedRewards);

//         var result = await _service.GetEligibleRewardsAsync(customer);

//         Assert.Equal(2, result.Count);
//         Assert.Equal("SPORTS", result[0].Channel);
//         Assert.Equal("CHAMPIONS_LEAGUE_FINAL_TICKET", result[0].RewardName);
//     }

//     [Fact]
//     public async Task GetEligibleRewardsAsync_ShouldReturnEmptyList_WhenCustomerHasNoEligibleChannels()
//     {
//         var customer = new Customer
//         {
//             AccountNumber = "12345",
//             SubscribedChannels = new List<string> { "KIDS", "NEWS" }
//         };

//         _mockRepository.Setup(repo => repo.GetRewardsByChannelsAsync(customer.SubscribedChannels))
//                        .ReturnsAsync(new List<Reward>());

//         var result = await _service.GetEligibleRewardsAsync(customer);

//         Assert.Empty(result);
//     }
// }