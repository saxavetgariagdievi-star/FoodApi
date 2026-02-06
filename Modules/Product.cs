namespace FoodApi.Modules
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal ProductTotal { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }

    // Navigation property ✅
        public Category? Category { get; set; }
    }
}