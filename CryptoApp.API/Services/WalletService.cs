using AutoMapper;
using CryptoApp.API.Dtos;
using CryptoApp.API.Models;
using CryptoApp.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<WalletsVM> CreateAsync(NewWalletDto r)
        {
            var currency = await _context.Currencies
                .Where(x => x.ShortName == r.Currency)
                .SingleOrDefaultAsync();

            if (currency == null)
                return null;

            var entity = _mapper.Map<Wallet>(r);

            _context.Add(entity);
            await _context.SaveChangesAsync();

            var m = _mapper.Map<WalletsVM>(entity);
            m.Currency = currency.ShortName;

            return m;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntityVM>> GetAllAsync<TEntityVM>() where TEntityVM : IEntityVM
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
            where TEntityVM : IEntityVM
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
