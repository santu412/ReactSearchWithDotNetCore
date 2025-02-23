namespace SEARCHAPI.BackEnd.Services;
using SEARCHAPI.BackEnd.Models;
public interface IRewardsService
{
    Task<(List<Reward> Rewards, int TotalCount)> GetEligibleRewardsAsync(Customer customer, int page, int pageSize);
}