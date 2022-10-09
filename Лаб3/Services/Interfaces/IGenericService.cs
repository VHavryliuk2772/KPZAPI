using Domain.Models;
using ViewModels.BaseDTOs;

namespace Services.Interfaces
{
    public interface IGenericService<T> where T : BaseModel
    {
        Task<int> CreateAsync<TSource>(TSource dto);
        Task<TResult> GetByIdAsync<TResult>(int id);
        Task<List<TResult>> GetAllAsync<TResult>() where TResult : class;
        Task UpdateAsync<TSource>(TSource dto) where TSource : BaseIdDTO;
        Task DeleteByIdAsync(int id);
    }
}
