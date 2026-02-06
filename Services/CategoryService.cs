using AutoMapper;
using FoodApi.DTOs.Cate;
using FoodApi.Interfaces.Services;
using FoodApi.Modules;
using FoodApi.Reposities.interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repo;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Tüm kategorileri getir
        public async Task<List<IEnumerable<CategoryRepoDto>>> GetAllAsync()
        {
            var categories = await _repo.Query()
            .Include(c => c.Products)
            .ToListAsync();

            var dtos = _mapper.Map<List<CategoryRepoDto>>(categories);
            return new List<IEnumerable<CategoryRepoDto>> { dtos };
        }

        // Tek kategori getir
        public async Task<List<CategoryRepoDto>> GetByIdAsync(int id)
        {
            var category = await _repo.Query()
            .Include(c => c.Products)
            .Where(c => c.Id == id)
            .ToListAsync();

            var dtos = _mapper.Map<List<CategoryRepoDto>>(category);
            return dtos;
        }

        // Yeni kategori oluştur
        public async Task<CategoryRepoDto> CreateAsync(CategoryCreateDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();

            return _mapper.Map<CategoryRepoDto>(entity);
        }

        // Kategori güncelle
        public async Task<CategoryRepoDto> UpdateAsync(int id, CategoryUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Category not found");

            _mapper.Map(dto, entity);
            _repo.Update(entity);
            await _repo.SaveChangesAsync();

            return _mapper.Map<CategoryRepoDto>(entity);
        }

        // Kategori sil
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return false;

            _repo.Delete(entity);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}

