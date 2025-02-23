
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

using SEARCHAPI.BackEnd.Services;
using SEARCHAPI.BackEnd.Models;



namespace SEARCHAPI.BackEnd.Controllers{
[ApiController]
[Route("api/rewards")]
public class RewardsController : ControllerBase
{
    private readonly IRewardsService _service;

    public RewardsController(IRewardsService service)
    {
        _service = service;
    }

   [HttpPost("getRewards")]
public async Task<IActionResult> GetRewards([FromBody] Customer customer, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
{
    if (customer == null || string.IsNullOrWhiteSpace(customer.AccountNumber))
        return BadRequest("Invalid customer details");

    var (rewards, totalCount) = await _service.GetEligibleRewardsAsync(customer, page, pageSize);

    return Ok(new
    {
        AccountNumber = customer.AccountNumber,
        Rewards = rewards,
        Page = page,
        PageSize = pageSize,
        TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
    });
}
}
}