using FoodApi.DTOs;
using FoodApi.DTOs.Cate;
using FoodApi.Modules;
using FoodApi.Response;

namespace FoodApi.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<List<IEnumerable<CategoryRepoDto>>> GetAllAsync();
        Task<List<CategoryRepoDto>> GetByIdAsync(int id);
        Task<CategoryRepoDto> CreateAsync(CategoryCreateDto dto);
        Task<CategoryRepoDto> UpdateAsync(int id, CategoryUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
