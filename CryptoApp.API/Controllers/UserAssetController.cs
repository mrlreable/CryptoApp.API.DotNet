using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.Services;
using CryptoApp.API.ViewModels;
using CryptoApp.Common;
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
        [HttpGet("userStocks/all")]
        [Authorize(Roles = UserRoles.AppUser)]
        public async Task<IEnumerable<StockVM>> GetAll()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return await _assetService.GetAllStocksAsync(user.Id);
        }

        // POST api/<UserAssetController>
        [HttpPost("purchase/stocks")]
        [Authorize(Roles = UserRoles.AppUser)]
        public async Task<IActionResult> Purchase([FromBody] BuyAssetDto buyAssetDto)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var (vm, message) = await _assetService.BuyAssetAsync(user, buyAssetDto);

            if (message == UserAssetState.InvalidAmount)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Status = "Error", Message = "Purchase failed. Amount has to be greater than 0." });

            if (message == UserAssetState.NotEnoughBalance)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Status = "Error", Message = "Purchase failed. Wallet has no sufficient amount to purchase." });

            if (message == UserAssetState.WalletNotExist)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Status = "Error", Message = "Purchase failed. User has no wallet added." });

            if (message == UserAssetState.StockNotExist)
                return StatusCode(StatusCodes.Status404NotFound,
                    new { Status = "Error", Message = "Purchase failed. Stock does not exist or it is not supported to trade." });

            return CreatedAtAction(nameof(GetUserAssetById), new { user.Id, vm.AssetId }, vm);
        }

        [HttpGet("userAsset")]
        public async Task<IActionResult> GetUserAssetById(string userId, int assetId)
        {
            var result = await _assetService.GetByIdsAsync(userId, assetId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT api/<UserAssetController>/5
        [HttpPut("sell/stocks")]
        [Authorize(Roles = UserRoles.AppUser)]
        public async Task<IActionResult> Put([FromBody] BuyAssetDto assetDto)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var (vm, message) = await _assetService.SellAsync(user, assetDto);

            if (message == UserAssetState.NotEnoughBalance)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Status = "Error", Message = "Purchase failed. Amount to be sold exceeds the balance." });

            if (message == UserAssetState.InvalidAmount)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Status = "Error", Message = "Purchase failed. Amount has to be greater than 0." });

            if (message == UserAssetState.UserAssetNotExist)
                return StatusCode(StatusCodes.Status404NotFound,
                    new { Status = "Error", Message = "Purchase failed. User has no amount to sell." });

            if (message == UserAssetState.WalletNotExist)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Status = "Error", Message = "Purchase failed. User has no wallet added." });

            if (message == UserAssetState.StockNotExist)
                return StatusCode(StatusCodes.Status404NotFound,
                    new { Status = "Error", Message = "Purchase failed. Stock Id does not exist." });

            return CreatedAtAction(nameof(GetUserAssetById), new { user.Id, vm.AssetId }, vm);
        }
    }
}
