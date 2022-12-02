using CryptoApp.API.Dtos;
using CryptoApp.API.ViewModels;
using System.Linq.Expressions;

namespace CryptoApp.API.Services
{
    public interface IEntityService
    {
        Task<TEntityVM> CreateAsync<TEntity, TEntityDto, TEntityVM>(TEntityDto r) 
            where TEntity : class
            where TEntityDto : IEntityDto
            where TEntityVM : IEntityVM;

        Task<bool> DeleteAsync(int id);

        //Task<List<TEntityVM>> GetAllAsync(GenericQueryOption<RecipeFilter> options);
        Task<List<TEntityVM>> GetAllAsync<TEntityVM>()
            where TEntityVM : IEntityVM;

        Task<TEntityVM> GetByIdAsync<TEntityVM>(int id)
            where TEntityVM : IEntityVM;

        Task<List<TEntityVM>> GetWhereAsync<TEntityVM, TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntityVM : IEntityVM
            where TEntity : class;

        Task<bool> UpdateRecipeAsync<TEntityDto>(int id, TEntityDto r)
            where TEntityDto : IEntityDto;
    }
}
