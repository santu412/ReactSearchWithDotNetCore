namespace SEARCHAPI.BackEnd.Services;
using Microsoft.Extensions.Caching.Memory;
using SEARCHAPI.BackEnd.Repositories;
using SEARCHAPI.BackEnd.Models;

public class RewardsService : IRewardsService
{
    private readonly IRewardsRepository _repository;
    private readonly IMemoryCache _cache;

    public RewardsService(IRewardsRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<(List<Reward>, int)> GetEligibleRewardsAsync(Customer customer, int page, int pageSize)
    {
        string cacheKey = $"rewards_{customer.AccountNumber}_page{page}";
        if (!_cache.TryGetValue(cacheKey, out (List<Reward> Rewards, int TotalCount) cachedRewards))
        {
            var result = await _repository.GetRewardsByChannelsAsync(customer.SubscribedChannels, page, pageSize);

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };
            _cache.Set(cacheKey, result, cacheOptions);

            return result;
        }

        return cachedRewards;
    }
}