using FoodApi.DTOs;
using FoodApi.DTOs.Cate;
using FoodApi.DTOs.Romas;
using FoodApi.Modules;
using FoodApi.Response;

namespace FoodApi.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<IEnumerable<ProductRepoDto>>> GetAllAsync();
        Task<List<ProductRepoDto>> GetByIdAsync(int id);
        Task<ProductRepoDto> CreateAsync(ProductCreateDto dto);
        Task<ProductRepoDto> UpdateAsync(int id, ProductUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}