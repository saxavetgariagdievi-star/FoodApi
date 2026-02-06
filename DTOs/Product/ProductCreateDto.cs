using System.ComponentModel.DataAnnotations;
using FoodApi.DTOs.Cate;

namespace FoodApi.DTOs.Romas
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal ProductTotal { get; set; }
        public string ImgUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }

    }
}