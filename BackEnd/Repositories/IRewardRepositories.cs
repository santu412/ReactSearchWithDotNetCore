namespace SEARCHAPI.BackEnd.Repositories;

using SEARCHAPI.BackEnd.Models;
public interface IRewardsRepository
{
   Task<(List<Reward> Rewards, int TotalCount)> GetRewardsByChannelsAsync(List<string> channels, int page, int pageSize);
}