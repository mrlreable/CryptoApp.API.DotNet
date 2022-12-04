using AutoMapper;
using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.ViewModels;
using CryptoApp.Common;
using Microsoft.EntityFrameworkCore;

namespace CryptoApp.API.Services
{
    public class StockService
    {
        private readonly CryptoContext _context;
        private readonly ILogger<UserAssetService> _serviceLogger;
        private readonly IMapper _mapper;

        public StockService(CryptoContext context, ILogger<UserAssetService> logger, IMapper mapper)
        {
            _context = context;
            _serviceLogger = logger;
            _mapper = mapper;
        }

        public async Task<StockVM> CreateStockAsync(User user, NewStockDto dto)
        {
            var existingStock = await _context.Stocks.Where(s => s.ShortName == dto.ShortName).ToListAsync();

            if (existingStock.Any())
                return null;

            var entity = new Stock
            {
                Price = dto.Price,
                Spread = dto.Spread,
                Name = dto.Name,
                ShortName = dto.ShortName,
                IsSupported = dto.IsSupported,
                Change = dto.Change,
                Description = dto.Description,
                UpdatedAt = DateTime.Now,
                UpdatedById = user.Id
            };

            _context.Stocks.Add(entity);
            await _context.SaveChangesAsync();

            return new StockVM
            {
                Id = entity.Id,
                Price = entity.Price,
                Spread = entity.Spread,
                Name = entity.Name,
                ShortName = entity.ShortName,
                Change = dto.Change,
                Description = dto.Description,
            };
        }

        public async Task<StockVM> GetByIdAsync(int stockId)
        {
            var asset = await _context.Stocks.Where(s => s.Id == stockId).SingleOrDefaultAsync();

            // In this context it means the total amount currently users have
            double totalPurchased = await _context.UserStocks.Where(us => us.StockId == stockId).SumAsync(us => us.Balance);

            if (asset == null)
                return null;

            return new StockVM
            {
                Id = stockId,
                Name = asset.Name,
                ShortName = asset.ShortName,
                Price = asset.Price,
                Spread = asset.Spread,
                Change = asset.Change,
                Description = asset.Description,
                TotalPurchased = totalPurchased
            };
        }

        internal async Task<IEnumerable<StockVM>> GetAllAsync()
        {
            var stocks = await _context.Stocks.ToListAsync();
            List<StockVM> result = new List<StockVM>();

            foreach (var stock in stocks)
            {
                result.Add(new StockVM
                {
                    Id = stock.Id,
                    Name = stock.Name,
                    ShortName = stock.ShortName,
                    Price = stock.Price,
                    Spread = stock.Spread,
                    Change = stock.Change,
                    Description = stock.Description,
                });
            }

            return result;
        }

        public async Task<StockVM> UpdateAsync(User admin, UpdateStockDto dto)
        {
            var stock = await _context.Stocks
                .Where(s => s.Id == dto.Id)
                .SingleOrDefaultAsync();

            if (stock == null)
                return null;

            stock.Price = dto?.Price ?? stock.Price;
            stock.Spread = dto?.Spread ?? stock.Spread;
            stock.IsSupported = dto?.IsSupported ?? stock.IsSupported;
            stock.Description = dto?.Description ?? stock.Description;
            stock.UpdatedById = admin.Id;
            stock.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new StockVM
            {
                Id = stock.Id,
                Name = stock.Name,
                ShortName = stock.ShortName,
                Price = stock.Price,
                Spread = stock.Spread,
                Change = stock.Change,
                Description = stock.Description,
            };
        }

        public async Task<UserAssetState> DeleteAsync(int id)
        {
            var stock = await _context.Stocks
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            if (stock == null)
                return UserAssetState.StockNotExist;

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return UserAssetState.Ok;
        }
    }
}
