using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.Services;
using CryptoApp.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        public WalletController(WalletService walletService, ILogger<WalletController> logger)
        {
            _walletService = walletService;
            _logger = logger;
        }

        [HttpPost("wallet")]
        public async Task<IActionResult> Post([FromBody] NewWalletDto walletDto)
        {
            var createdWallet = await _walletService.CreateAsync(walletDto);

            if (createdWallet == null)
                return NotFound();

            return CreatedAtAction(nameof(GetById), new { createdWallet.Id }, createdWallet);
        }

        [HttpGet("wallet/{id}")]
        private async Task<IActionResult> GetById(int walletId)
        {
            var result = await _walletService.GetByIdAsync(walletId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
