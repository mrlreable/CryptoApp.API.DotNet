using AutoMapper;
using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace CryptoApp.API.Services
{
    public class UserAssetService
    {
        private readonly CryptoContext _context;
        private readonly ILogger<UserAssetService> _serviceLogger;
        private readonly IMapper _mapper;

        public UserAssetService(CryptoContext context, ILogger<UserAssetService> logger, IMapper mapper)
        {
            _context = context;
            _serviceLogger = logger;
            _mapper = mapper;
        }

        public async Task<UserAssetVM> GetByIdAsync(string userId, int assetId)
        {
            var userAsset = await _context.UserStocks.Where(x => x.UserId == userId && x.StockId == assetId).SingleOrDefaultAsync();

            if (userAsset == null)
                return null;

            return new UserAssetVM
            {
                AssetId = assetId,
                AssetName = userAsset.Stock.Name,
                AssetShortName = userAsset.Stock.ShortName,
                Amount = userAsset.Balance
            };
        }

        public async Task<UserAssetVM> BuyStockAsync(User user, BuyAssetDto dto)
        {
            try
            {
                var userWallet = await _context.Wallets.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
                var asset = await _context.Stocks.Where(s => s.Id == dto.AssetId).SingleOrDefaultAsync();

                if (userWallet?.Balance < dto.Amount || userWallet == null || asset == null)
                    return null;

                userWallet.Balance -= dto.Amount;

                var existingUserAsset = await _context.UserStocks.Where(x => x.UserId == user.Id && x.StockId == dto.AssetId).SingleOrDefaultAsync();

                if (existingUserAsset != null)
                {
                    existingUserAsset.Balance += dto.Amount;
                    //_context.UserStocks.Add(existingUserAsset);
                    await _context.SaveChangesAsync();

                    return new UserAssetVM
                    {
                        AssetId = existingUserAsset.StockId,
                        AssetName = asset.Name,
                        AssetShortName = asset.ShortName,
                        Amount = existingUserAsset.Balance
                    };
                }

                user.Stocks = new List<Stock>();
                asset.Users= new List<User>();

                user.Stocks.Add(asset);
                asset.Users.Add(user);
                await _context.SaveChangesAsync();

                var userStock = await _context.UserStocks.Where(x => x.UserId == user.Id && x.StockId == dto.AssetId).SingleOrDefaultAsync();
                userStock.Balance = dto.Amount;
                userStock.LatestPurchase = DateTime.Now;

                //_context.UserStocks.Add(userStock);
                //_context.Wallets.Add(userWallet);
                await _context.SaveChangesAsync();

                return new UserAssetVM
                {
                    AssetId = userStock.StockId,
                    AssetName = asset.Name,
                    AssetShortName = asset.ShortName,
                    Amount = userStock.Balance
                };
            }
            catch (Exception ex)
            {
                _serviceLogger.LogError($"Error in BuyStockAsync(). Message: {ex.Message}, Stack: {ex.StackTrace}");
                return null;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StockVM>> GetAllStocksAsync(string userId)
        {
            var result = await _context.UserStocks
                .Include(x => x.Stock)
                .Where(x => x.UserId == userId)
                .Select(x => new { 
                    x.StockId, 
                    x.Stock.Id, 
                    x.Stock.Name, 
                    x.Stock.ShortName, 
                    x.Stock.Change, 
                    x.Stock.Spread, 
                    x.Stock.Price,
                    x.Balance
                })
                .ToListAsync();

            return result.Select(x => _mapper.Map<StockVM>(x));
        }

        public Task<TEntityVM> GetByIdAsync<TEntityVM>(int id) where TEntityVM : IAssetVM
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntityVM>> GetWhereAsync<TEntityVM, TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntityVM : IAssetVM
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync<TEntityDto>(int id, TEntityDto r) where TEntityDto : IEntityDto
        {
            throw new NotImplementedException();
        }
    }
}
