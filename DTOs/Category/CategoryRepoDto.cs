using FoodApi.Modules;

namespace FoodApi.DTOs.Cate
{
    public class CategoryRepoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ImgUrl { get; set; }
        public decimal Investment { get; set; }
    }
}