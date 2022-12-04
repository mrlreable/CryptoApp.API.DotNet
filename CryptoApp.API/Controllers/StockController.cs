using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.Services;
using CryptoApp.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoApp.API.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;
        private readonly ILogger<WalletController> _logger;
        private readonly UserManager<User> _userManager;

        public StockController(StockService stockService, ILogger<WalletController> logger, UserManager<User> userManager)
        {
            _stockService = stockService;
            _logger = logger;
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        // GET: api/<StockController>
        [HttpGet]
        public async Task<IEnumerable<StockVM>> GetAll()
        {
            return await _stockService.GetAllAsync();
        }

        // POST api/<StockController>
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Post([FromBody] NewStockDto dto)
        {
            var admin = await _userManager.GetUserAsync(HttpContext.User);
            var createdStock = await _stockService.CreateStockAsync(admin, dto);

            if (createdStock == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Status = "Error", Message = "Stock adding failed. Stock already exists." });
            }

            return CreatedAtAction(nameof(GetStockById), new { createdStock.Id }, createdStock);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById(int id)
        {
            var result = await _stockService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT api/<StockController>/5
        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Put([FromBody] UpdateStockDto dto)
        {
            var admin = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _stockService.UpdateAsync(admin, dto);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Status = "Error", Message = "Error updating stock. Stock does not exist." });
            }

            return CreatedAtAction(nameof(GetStockById), new { result.Id }, result);
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _stockService.DeleteAsync(id);

            if (result == Common.UserAssetState.StockNotExist)
                return StatusCode(StatusCodes.Status204NoContent,
                new { Status = "No Content", Message = "Stock does not exist." });

            return StatusCode(StatusCodes.Status200OK,
                new { Status = "OK", Message = "Stock successfully deleted." });
        }
    }
}
