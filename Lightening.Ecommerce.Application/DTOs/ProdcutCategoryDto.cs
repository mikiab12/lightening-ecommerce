namespace Lightening.Ecommerce.Application.DTOs
{
    public class ProdcutCategoryDto
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<ProdcutSubcategoryDto> ProductSubcategories { get; set; }
    }

    public class ProdcutSubcategoryDto
    {
        public int ProductSubcategoryId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = null!;
    }
}
