using AutoMapper;
using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.ViewModels;
using CryptoApp.Common;
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

        public async Task<UserAssetVM> GetByIdsAsync(string userId, int assetId)
        {
            var userAsset = await _context.UserStocks.Where(x => x.UserId == userId && x.StockId == assetId).SingleOrDefaultAsync();
            var asset = await _context.Stocks.Where(s => s.Id == assetId).SingleOrDefaultAsync();

            if (userAsset == null || asset == null)
                return null;

            return new UserAssetVM
            {
                AssetId = assetId,
                AssetName = asset.Name,
                AssetShortName = asset.ShortName,
                Total = userAsset.Balance,
                Amount = userAsset.Balance
            };
        }

        public async Task<(UserAssetVM? Asset, UserAssetState Message)> SellAsync(User user, BuyAssetDto dto)
        {
            var userWallet = await _context.Wallets.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
            var asset = await _context.Stocks.Where(s => s.Id == dto.AssetId).SingleOrDefaultAsync();

            if (dto.Amount <= 0)
                return (null, UserAssetState.InvalidAmount);

            if (userWallet == null)
                return (null, UserAssetState.WalletNotExist);

            if (asset == null)
                return (null, UserAssetState.StockNotExist);

            userWallet.Balance += dto.Amount * asset.Price;

            var existingUserAsset = await _context.UserStocks.Where(x => x.UserId == user.Id && x.StockId == dto.AssetId).SingleOrDefaultAsync();

            if (existingUserAsset == null)
                return (null, UserAssetState.UserAssetNotExist);

            if (dto.Amount > existingUserAsset.Balance)
                return (null, UserAssetState.NotEnoughBalance);

            existingUserAsset.Balance -= dto.Amount;

            var assetVM = new UserAssetVM
            {
                AssetId = existingUserAsset.StockId,
                AssetName = asset.Name,
                AssetShortName = asset.ShortName,
                Amount = dto.Amount,
                Total = existingUserAsset.Balance
            };

            if (existingUserAsset.Balance == 0)
                _context.Remove(existingUserAsset);

            await _context.SaveChangesAsync();

            return (assetVM, UserAssetState.Ok);
        }

        public async Task<(UserAssetVM? Asset, UserAssetState Message)> BuyAssetAsync(User user, BuyAssetDto dto)
        {
            try
            {
                var userWallet = await _context.Wallets.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
                var asset = await _context.Stocks.Where(s => s.Id == dto.AssetId && s.IsSupported).SingleOrDefaultAsync();

                if (dto.Amount <= 0)
                    return (null, UserAssetState.InvalidAmount);

                if (asset == null)
                    return (null, UserAssetState.StockNotExist);

                if (userWallet?.Balance < dto.Amount)
                    return (null, UserAssetState.NotEnoughBalance);

                if (userWallet == null)
                    return (null, UserAssetState.WalletNotExist);


                userWallet.Balance -= dto.Amount * asset.Price;

                var existingUserAsset = await _context.UserStocks.Where(x => x.UserId == user.Id && x.StockId == dto.AssetId).SingleOrDefaultAsync();

                if (existingUserAsset != null)
                {
                    existingUserAsset.Balance += dto.Amount;
                    await _context.SaveChangesAsync();

                    var assetVM = new UserAssetVM
                    {
                        AssetId = existingUserAsset.StockId,
                        AssetName = asset.Name,
                        AssetShortName = asset.ShortName,
                        Amount = dto.Amount,
                        Total = existingUserAsset.Balance
                    };
                    return (assetVM, UserAssetState.Ok);
                }

                user.Stocks = new List<Stock>();
                asset.Users = new List<User>();

                user.Stocks.Add(asset);
                asset.Users.Add(user);
                await _context.SaveChangesAsync();

                var userStock = await _context.UserStocks.Where(x => x.UserId == user.Id && x.StockId == dto.AssetId).SingleOrDefaultAsync();
                userStock.Balance = dto.Amount;
                userStock.LatestPurchase = DateTime.Now;

                await _context.SaveChangesAsync();

                var assetVm = new UserAssetVM
                {
                    AssetId = userStock.StockId,
                    AssetName = asset.Name,
                    AssetShortName = asset.ShortName,
                    Total = userStock.Balance,
                    Amount = dto.Amount
                };
                return (assetVm, UserAssetState.Ok);
            }
            catch (Exception ex)
            {
                _serviceLogger.LogError($"Error in BuyStockAsync(). Message: {ex.Message}, Stack: {ex.StackTrace}");
                return (null, UserAssetState.Error);
            }
        }

        public async Task<IEnumerable<StockVM>> GetAllStocksAsync(string userId)
        {
            var result = await _context.UserStocks
                .Include(x => x.Stock)
                .Where(x => x.UserId == userId)
                .Select(x => new
                {
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

            var vmList = new List<StockVM>();

            foreach (var item in result)
            {
                vmList.Add(new StockVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    ShortName = item.ShortName,
                    Change = item.Change,
                    Spread = item.Spread,
                    Price = item.Price,
                    TotalPurchased = item.Balance
                });
            }

            return vmList;
        }
    }
}
