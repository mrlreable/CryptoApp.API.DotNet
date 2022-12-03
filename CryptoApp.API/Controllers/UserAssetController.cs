using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.Services;
using CryptoApp.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoApp.API.Controllers
{
    [Route("api/assets")]
    [ApiController]
    public class UserAssetController : ControllerBase
    {
        private readonly UserAssetService _assetService;
        private readonly ILogger<WalletController> _logger;
        private readonly UserManager<User> _userManager;

        public UserAssetController(ILogger<WalletController> logger, UserAssetService service, UserManager<User> userManager)
        {
            _logger = logger;
            _assetService = service;
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        // GET: api/<UserAssetController>
        [HttpGet("stocks")]
        public async Task<IEnumerable<StockVM>> Get()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return await _assetService.GetAllStocksAsync(user.Id);
        }

        // POST api/<UserAssetController>
        [HttpPost("buy/stocks")]
        [Authorize(Roles = UserRoles.AppUser)]
        public async Task<IActionResult> Post([FromBody] BuyAssetDto buyAssetDto)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var result = await _assetService.BuyStockAsync(user, buyAssetDto);

            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { user.Id, result.AssetId }, result);
        }

        [HttpGet("userAsset/assetId")]
        public async Task<IActionResult> GetById(string userId, int assetId)
        {
            var result = await _assetService.GetByIdAsync(userId, assetId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT api/<UserAssetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAssetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
