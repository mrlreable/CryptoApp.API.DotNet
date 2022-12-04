using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.Services;
using CryptoApp.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CryptoApp.API.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class WalletController : ControllerBase
    {
        private readonly WalletService _walletService;
        private readonly ILogger<WalletController> _logger;
        private readonly UserManager<User> _userManager;

        public WalletController(WalletService walletService, ILogger<WalletController> logger, UserManager<User> userManager)
        {
            _walletService = walletService;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost("wallets")]
        [Authorize(Roles = UserRoles.AppUser)]
        public async Task<IActionResult> Post([FromBody] NewWalletDto walletDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var (createdWallet, message) = await _walletService.CreateAsync(currentUser.Id, walletDto);

            if (message == Common.WalletState.CurrencyNotExist)
                return StatusCode(StatusCodes.Status404NotFound,
                    new { State = "Error", Message = "Wallet adding failed. Currency does not exist." });

            if (message == Common.WalletState.WalletExists)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { State = "Error", Message = "Wallet adding failed. Wallet already exists." });

            return CreatedAtAction(nameof(GetById), new { createdWallet.Id }, createdWallet);
        }

        [HttpGet("wallets")]
        [Authorize(Roles = UserRoles.AppUser)]
        public async Task<IEnumerable<WalletsVM>> GetAll()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            return await _walletService.GetAllAsync(currentUser);
        }

        [HttpDelete("wallets/{id}")]
        [Authorize(Roles = UserRoles.AppUser)]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var result = await _walletService.DeleteAsync(user, id);

            if (result == Common.WalletState.WalletNotExist)
                return StatusCode(StatusCodes.Status204NoContent,
                    new { Status = "No content", Message = "Wallet requested for deletion does not exist." });

            return StatusCode(StatusCodes.Status200OK,
                new { Status = "OK", Message = "Wallet successfully deleted." });
        }

        [HttpGet("wallets/{id}")]
        [Authorize(Roles = UserRoles.AppUser)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _walletService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
