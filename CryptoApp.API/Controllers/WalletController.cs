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

        [HttpPost("wallet")]
        [Authorize(Roles = UserRoles.AppUser)]
        public async Task<IActionResult> Post([FromBody] NewWalletDto walletDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var createdWallet = await _walletService.CreateAsync(currentUser.Id, walletDto);

            if (createdWallet == null)
                return NotFound();

            return CreatedAtAction(nameof(GetById), new { createdWallet.Id }, createdWallet);
        }

        [HttpGet("wallet/{id}")]
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
