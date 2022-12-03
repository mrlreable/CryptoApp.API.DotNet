using AutoMapper;
using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.ViewModels;
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

        public async Task<WalletsVM> CreateAsync(string userId, NewWalletDto r)
        {
            try
            {
                var currency = await _context.Currencies
                    .Where(x => x.ShortName == r.Currency)
                    .SingleOrDefaultAsync();

                var wallet = await _context.Wallets.Where(x => x.CardNumber == r.CardNumber).SingleOrDefaultAsync();

                if (currency == null || wallet != null)
                    return null;

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

                return new WalletsVM
                {
                    CardNumber= entity.CardNumber,
                    Cardholder= entity.Cardholder,
                    ExpirationDate = entity.ExpirationDate,
                    Balance = entity.Balance,
                    Currency = entity.Currency.ShortName
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntityVM>> GetAllAsync<TEntityVM>() where TEntityVM : IAssetVM
        {
            throw new NotImplementedException();
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
