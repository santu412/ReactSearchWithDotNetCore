namespace SEARCHAPI.BackEnd.Repositories;

using SEARCHAPI.BackEnd.Models;
public class RewardsRepository : IRewardsRepository
{
    private readonly Dictionary<string, string> _rewardsData = new()
    {
        { "SPORTS", "CHAMPIONS_LEAGUE_FINAL_TICKET" },
        { "KIDS", null },
        { "MUSIC", "KARAOKE_PRO_MICROPHONE" },
        { "NEWS", null },
        { "MOVIES", "PIRATES_OF_THE_CARIBBEAN_COLLECTION" }
    };

    public async Task<(List<Reward>, int)> GetRewardsByChannelsAsync(List<string> channels, int page, int pageSize)
    {
        var filteredRewards = channels
            .Where(channel => _rewardsData.ContainsKey(channel) && _rewardsData[channel] != null)
            .Select(channel => new Reward { Channel = channel, RewardName = _rewardsData[channel] })
            .ToList();

        int totalCount = filteredRewards.Count;
        var paginatedRewards = filteredRewards.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return await Task.FromResult((paginatedRewards, totalCount));
    }
}