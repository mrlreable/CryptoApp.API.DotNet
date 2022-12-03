using CryptoApp.API.Dtos;
using CryptoApp.API.ViewModels;
using System.Linq.Expressions;

namespace CryptoApp.API.Services
{
    public interface IAssetService
    {
        Task<TEntityVM> CreateAsync<TEntity, TEntityDto, TEntityVM>(TEntityDto r) 
            where TEntity : class
            where TEntityDto : IEntityDto
            where TEntityVM : IAssetVM;

        Task<bool> DeleteAsync(int id);

        //Task<List<TEntityVM>> GetAllAsync(GenericQueryOption<RecipeFilter> options);
        Task<List<TEntityVM>> GetAllAsync<TEntityVM>()
            where TEntityVM : IAssetVM;

        Task<TEntityVM> GetByIdAsync<TEntityVM>(int id)
            where TEntityVM : IAssetVM;

        Task<List<TEntityVM>> GetWhereAsync<TEntityVM, TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntityVM : IAssetVM
            where TEntity : class;

        Task<bool> UpdateAsync<TEntityDto>(int id, TEntityDto r)
            where TEntityDto : IEntityDto;
    }
}
