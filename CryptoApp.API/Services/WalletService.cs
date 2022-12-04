using AutoMapper;
using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.ViewModels;
using CryptoApp.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace CryptoApp.API.Services
{
    public class WalletService
    {
        private readonly CryptoContext _context;
        private readonly IMapper _mapper;

        public WalletService(CryptoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<(WalletsVM? Vm, WalletState Message)> CreateAsync(string userId, NewWalletDto r)
        {
            try
            {
                var currency = await _context.Currencies
                    .Where(x => x.ShortName == r.Currency)
                    .SingleOrDefaultAsync();

                var wallet = await _context.Wallets.Where(x => x.CardNumber == r.CardNumber).SingleOrDefaultAsync();

                if (currency == null)
                    return (null, WalletState.CurrencyNotExist);

                if (wallet != null)
                    return (null, WalletState.WalletExists);

                var entity = new Wallet
                {
                    CardNumber = r.CardNumber,
                    Cardholder = r.Cardholder,
                    ExpirationDate = r.ExpirationDate,
                    Balance = r.Balance,
                    Currency = currency,
                    UserId = userId,
                };

                _context.Add(entity);
                await _context.SaveChangesAsync();

                var vm = new WalletsVM
                {
                    CardNumber = entity.CardNumber,
                    Cardholder = entity.Cardholder,
                    ExpirationDate = entity.ExpirationDate,
                    Balance = entity.Balance,
                    Currency = entity.Currency.ShortName
                };
                return (vm, WalletState.Ok);
            }
            catch (Exception ex)
            {
                return (null, WalletState.Error);
            }
        }

        public async Task<WalletState> DeleteAsync(User user, int id)
        {
            var walletToDelete = await _context.Wallets
                .Where(w => w.UserId == user.Id && w.Id == id)
                .SingleOrDefaultAsync();

            if (walletToDelete == null)
                return WalletState.WalletNotExist;

            _context.Remove(walletToDelete);
            await _context.SaveChangesAsync();
            return WalletState.Ok;
        }

        public async Task<List<WalletsVM>> GetAllAsync(User user)
        {
            var userWallets = await _context.Wallets
                .Where(w => w.UserId == user.Id)
                .ToListAsync();

            var walletsVm = new List<WalletsVM>();

            foreach (var wallet in userWallets)
            {
                walletsVm.Add(new WalletsVM
                {
                    Id = wallet.Id,
                    CardNumber = wallet.CardNumber,
                    Cardholder = wallet.Cardholder,
                    ExpirationDate = wallet.ExpirationDate,
                    Balance = wallet.Balance
                });
            }

            return walletsVm;
        }

        public async Task<WalletsVM> GetByIdAsync(int id)
        {
            return await _context.Wallets
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<WalletsVM>(x))
                .SingleOrDefaultAsync();
        }

        public Task<List<TEntityVM>> GetWhereAsync<TEntityVM, TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntityVM : IAssetVM
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRecipeAsync<TEntityDto>(int id, TEntityDto r) where TEntityDto : IEntityDto
        {
            throw new NotImplementedException();
        }
    }
}
