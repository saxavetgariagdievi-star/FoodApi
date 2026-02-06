using System.ComponentModel.DataAnnotations;
using FoodApi.Modules;

namespace FoodApi.DTOs.Cate
{
    public class CategoryCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ImgUrl { get; set; }
        public decimal Investment { get; set; }
    
    }
}