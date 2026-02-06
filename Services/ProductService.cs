using AutoMapper;
using FoodApi.DTOs.Cate;
using FoodApi.DTOs.Romas;
using FoodApi.Interfaces.Services;
using FoodApi.Modules;
using FoodApi.Reposities.interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repo;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Tüm ürünleri getir
        public async Task<List<IEnumerable<ProductRepoDto>>> GetAllAsync()
        {
            var products = await _repo.Query()
                                      .Include(p => p.Category)
                                      .ToListAsync();

            var dtos = _mapper.Map<List<ProductRepoDto>>(products);
            return new List<IEnumerable<ProductRepoDto>> { dtos };
        }

        // Tek ürün getir
        public async Task<List<ProductRepoDto>> GetByIdAsync(int id)
        {
            var product = await _repo.Query()
                                     .Include(p => p.Category)
                                     .Where(p => p.Id == id)
                                     .ToListAsync();

            var dtos = _mapper.Map<List<ProductRepoDto>>(product);
            return dtos;
        }

        // Yeni ürün oluştur
        public async Task<ProductRepoDto> CreateAsync(ProductCreateDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();

            return _mapper.Map<ProductRepoDto>(entity);
        }

        // Ürün güncelle
        public async Task<ProductRepoDto> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Product not found");

            _mapper.Map(dto, entity);
            _repo.Update(entity);
            await _repo.SaveChangesAsync();

            return _mapper.Map<ProductRepoDto>(entity);
        }

        // Ürün sil
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

