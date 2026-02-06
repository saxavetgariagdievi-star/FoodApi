using AutoMapper;
using FoodApi.DTOs.Cate;
using FoodApi.DTOs.Romas;
using FoodApi.Modules;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // ProductCreateDto -> Product mapping
        CreateMap<ProductCreateDto, Product>();

        // ProductUpdateDto -> Product mapping
        CreateMap<ProductUpdateDto, Product>();

        // Category DTO mapping
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<CategoryUpdateDto, Category>();
        CreateMap<CategoryRepoDto, Category>();
        CreateMap<Category, CategoryRepoDto>();

        // Product entity -> ProductRepoDto
        CreateMap<Product, ProductRepoDto>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
            // თუ გინდა, შეგიძლია Category Name:
            //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));
    }
}


